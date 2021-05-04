import React, { useCallback, useEffect, useState } from 'react';
import { useHistory, useParams } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import Button from '@material-ui/core/Button';
import FormControl from '@material-ui/core/FormControl';
import FormHelperText from '@material-ui/core/FormHelperText';
import InputLabel from '@material-ui/core/InputLabel';
import MenuItem from '@material-ui/core/MenuItem';
import Paper from '@material-ui/core/Paper';
import Select from '@material-ui/core/Select';

import SaveIcon from '@material-ui/icons/Save';

import {
  initialFormState,
  validateFormState,
} from './helpers';

import {
  VALIDATION_ERROR_TYPE__VALUE_REQUIRED,
} from '../../availableValidationErrorTypes';

const InstallServerSoftwareApplicationEditor: React.VFC = () => {
  const history = useHistory();

  // Identyfikator wdrożenia.
  const { implementationId } = useParams();
  // Identyfikator środowiska.
  const { environmentId } = useParams();
  // Identyfikator serwera.
  const { serverId } = useParams();

  // Stan formularza.
  const [formState, setFormState] = useState(initialFormState());
  // Wynik walidacji stanu formularza.
  const [formStateValidationResult, setFormStateValidationResult] = useState(null);

  // Flaga określająca, czy lista oprogramowania została pobrana z API.
  const [isSoftwareApplicationsFetched, setIsSoftwareApplicationsFetched] = useState(false);
  // Lista oprogramowania.
  const [softwareApplications, setSoftwareApplications] = useState([]);

  const convertFetchedSoftwareApplications = (data) => {
    if (data && data.length > 0) {
      return data
        .filter((softwareApplication) => !softwareApplication.isDeleted)
        .sort((softwareApplication1, softwareApplication2) => softwareApplication1.name.localeCompare(softwareApplication2.name));
    }

    return [];
  };

  const fetchSoftwareApplications = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/configuration/software-applications`)
      .then((response) => response.json())
      .then((data) => {
        setIsSoftwareApplicationsFetched(true);
        setSoftwareApplications(convertFetchedSoftwareApplications(data));
      });
  }, []);

  useEffect(() => {
    fetchSoftwareApplications();
  }, [fetchSoftwareApplications]);

  const onSoftwareApplicationChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      softwareApplicationId: event.target.value,
    });
  };

  const onSave = async () => {
    const validationResult = validateFormState(formState);
    if (validationResult.isValid) {
      await fetch(
        `${window['env'].API_URL}/implementations/${implementationId}/environments/${environmentId}/servers/${serverId}/software-applications`,
        {
          body: JSON.stringify(formState),
          headers: {
            'Content-Type': 'application/json',
          },
          method: 'POST',
        },
      )
      .then((response) => {
        if (response.ok) {
          history.push(`/implementations/${implementationId}/environments/${environmentId}/servers/${serverId}`);
        } else {
          return response.json();
        }
      })
      .then((data) => {
        switch (data && data.errorType) {
          case VALIDATION_ERROR_TYPE__VALUE_REQUIRED: {
            setFormStateValidationResult({
              [data.property]: 'Pole wymagane.',
            });
            break;
          }
          default:
            break;
        }
      });
    } else {
      setFormStateValidationResult(validationResult.details);
    }
  };

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Zainstaluj oprogramowanie na serwerze
      </Box>
      <Box>
        <Paper>
          <Box
            px={4}
            pb={2}
            pt={4}
          >
            <FormControl
              error={formStateValidationResult && formStateValidationResult.softwareApplicationId !== undefined && formStateValidationResult.softwareApplicationId !== null}
              fullWidth
            >
              <InputLabel id="software-application-label">Oprogramowanie</InputLabel>
              <Select
                labelId="software-application-label"
                value={formState.softwareApplicationId}
                onChange={onSoftwareApplicationChange}
              >
                {
                  isSoftwareApplicationsFetched && softwareApplications.length > 0
                    ? (
                      softwareApplications.map((softwareApplication) => {
                        return (
                          <MenuItem
                            key={softwareApplication.id}
                            value={softwareApplication.id}
                          >
                            {softwareApplication.name}
                          </MenuItem>
                        );
                      })
                    )
                    : []
                }
              </Select>
              {
                formStateValidationResult && formStateValidationResult.softwareApplicationId !== undefined && formStateValidationResult.softwareApplicationId !== null
                  ? (<FormHelperText>{formStateValidationResult.softwareApplicationId}</FormHelperText>)
                  : null
              }
            </FormControl>
          </Box>
          <Box
            pb={3}
            pr={4}
            pt={1}
            textAlign="right"
          >
            <Button
              color="primary"
              size="small"
              startIcon={<SaveIcon />}
              variant="contained"
              onClick={onSave}
            >
              Zapisz
            </Button>
          </Box>
        </Paper>
      </Box>
    </>
  )
}

export default InstallServerSoftwareApplicationEditor;