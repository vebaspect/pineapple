import React, { useCallback, useEffect, useState } from 'react';
import { Link as RouterLink, useHistory, useParams } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import Button from '@material-ui/core/Button';
import FormControl from '@material-ui/core/FormControl';
import FormHelperText from '@material-ui/core/FormHelperText';
import InputLabel from '@material-ui/core/InputLabel';
import Link from '@material-ui/core/Link';
import MenuItem from '@material-ui/core/MenuItem';
import Paper from '@material-ui/core/Paper';
import Select from '@material-ui/core/Select';
import TextField from '@material-ui/core/TextField';

import SaveIcon from '@material-ui/icons/Save';

import {
  initialFormState,
  validateFormState,
} from './helpers';

import {
  VALIDATION_ERROR_TYPE__VALUE_REQUIRED,
} from '../../availableValidationErrorTypes';

const CreateServerEditor: React.VFC = () => {
  const history = useHistory();

  // Identyfikator wdrożenia.
  const { implementationId } = useParams();
  // Identyfikator środowiska.
  const { environmentId } = useParams();

  // Flaga określająca, czy wdrożenie zostało pobrane z API.
  const [isImplementationFetched, setIsImplementationFetched] = useState(false);
  // Wdrożenie.
  const [implementation, setImplementation] = useState(null);

  // Flaga określająca, czy środowisko zostało pobrane z API.
  const [isEnvironmentFetched, setIsEnvironmentFetched] = useState(false);
  // Środowisko.
  const [environment, setEnvironment] = useState(null);

  // Stan formularza.
  const [formState, setFormState] = useState(initialFormState());
  // Wynik walidacji stanu formularza.
  const [formStateValidationResult, setFormStateValidationResult] = useState(null);

  // Flaga określająca, czy lista systemów operacyjnych została pobrana z API.
  const [isOperatingSystemsFetched, setIsOperatingSystemsFetched] = useState(false);
  // Lista systemów operacyjnych.
  const [operatingSystems, setOperatingSystems] = useState([]);

  const fetchImplementation = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/implementations/${implementationId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsImplementationFetched(true);
        setImplementation(data);
      });
  }, [implementationId]);

  useEffect(() => {
    fetchImplementation();
  }, [fetchImplementation]);

  const fetchEnvironment = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/implementations/${implementationId}/environments/${environmentId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsEnvironmentFetched(true);
        setEnvironment(data);
      });
  }, [implementationId, environmentId]);

  useEffect(() => {
    fetchEnvironment();
  }, [fetchEnvironment]);

  const convertFetchedOperatingSystems = (data) => {
    if (data && data.length > 0) {
      return data
        .filter((operatingSystem) => !operatingSystem.isDeleted)
        .sort((operatingSystem1, operatingSystem2) => operatingSystem1.name.localeCompare(operatingSystem2.name));
    }

    return [];
  };

  const fetchOperatingSystems = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/configuration/operating-systems`)
      .then((response) => response.json())
      .then((data) => {
        setIsOperatingSystemsFetched(true);
        setOperatingSystems(convertFetchedOperatingSystems(data));
      });
  }, []);

  useEffect(() => {
    fetchOperatingSystems();
  }, [fetchOperatingSystems]);

  const onNameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      name: event.target.value,
    });
  };

  const onSymbolChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      symbol: event.target.value,
    });
  };

  const onIpAddressChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      ipAddress: event.target.value,
    });
  };

  const onOperatingSystemChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      operatingSystemId: event.target.value,
    });
  };

  const onDescriptionChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      description: event.target.value,
    });
  };

  const onCancel = () => {
    history.push(`/implementations/${implementationId}/environments/${environmentId}`);
  };

  const onSave = async () => {
    const validationResult = validateFormState(formState);
    if (validationResult.isValid) {
      await fetch(
        `${window['env'].API_URL}/implementations/${implementationId}/environments/${environmentId}/servers`,
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
          history.push(`/implementations/${implementationId}/environments/${environmentId}`);
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
        fontSize="0.9rem"
        m={2}
      >
        <Link
          component={RouterLink}
          to="/implementations"
        >
          Wdrożenia
        </Link>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        <Link
          component={RouterLink}
          to={`/implementations/${implementationId}`}
        >
          {
            isImplementationFetched
              ? (
                <Box component="span">
                  {implementation?.name}
                </Box>)
              : ''
          }
        </Link>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        <Box component="span">
          Środowiska
        </Box>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        <Link
          component={RouterLink}
          to={`/implementations/${implementationId}/environments/${environmentId}`}
        >
          {
            isEnvironmentFetched
              ? (
                <Box component="span">
                  {environment?.name}
                </Box>)
              : ''
          }
        </Link>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        <Box component="span">
          Serwery
        </Box>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        <Box component="span">
          Dodaj
        </Box>
      </Box>
      <Box>
        <Paper>
          <Box
            px={4}
            pb={2}
            pt={4}
          >
            <FormControl fullWidth>
              <TextField
                label="Nazwa"
                helperText={formStateValidationResult?.name || 'Maksymalnie 200 znaków.'}
                inputProps={{ maxLength: 200 }}
                error={formStateValidationResult && formStateValidationResult.name !== undefined && formStateValidationResult.name !== null}
                value={formState.name}
                onChange={onNameChange}
              />
            </FormControl>
          </Box>
          <Box
            px={4}
            pb={2}
          >
            <FormControl fullWidth>
              <TextField
                label="Symbol"
                helperText={formStateValidationResult?.symbol || 'Maksymalnie 200 znaków.'}
                inputProps={{ maxLength: 200 }}
                error={formStateValidationResult && formStateValidationResult.symbol !== undefined && formStateValidationResult.symbol !== null}
                value={formState.symbol}
                onChange={onSymbolChange}
              />
            </FormControl>
          </Box>
          <Box
            px={4}
            pb={2}
          >
            <FormControl fullWidth>
              <TextField
                label="Adres IP"
                helperText={formStateValidationResult?.ipAddress || 'Maksymalnie 100 znaków.'}
                inputProps={{ maxLength: 100 }}
                error={formStateValidationResult && formStateValidationResult.ipAddress !== undefined && formStateValidationResult.ipAddress !== null}
                value={formState.ipAddress}
                onChange={onIpAddressChange}
              />
            </FormControl>
          </Box>
          <Box
            px={4}
            pb={2}
          >
            <FormControl
              error={formStateValidationResult && formStateValidationResult.operatingSystemId !== undefined && formStateValidationResult.operatingSystemId !== null}
              fullWidth
            >
              <InputLabel id="operating-system-label">System operacyjny</InputLabel>
              <Select
                labelId="operating-system-label"
                value={formState.operatingSystemId}
                onChange={onOperatingSystemChange}
              >
                {
                  isOperatingSystemsFetched && operatingSystems.length > 0
                    ? (
                      operatingSystems.map((operatingSystem) => {
                        return (
                          <MenuItem
                            key={operatingSystem.id}
                            value={operatingSystem.id}
                          >
                            {operatingSystem.name}
                            <Box
                              component="span"
                              color="text.secondary"
                              mx={0.5}
                            >
                              ({operatingSystem.symbol})
                            </Box>
                          </MenuItem>
                        );
                      })
                    )
                    : []
                }
              </Select>
              {
                formStateValidationResult && formStateValidationResult.operatingSystemId !== undefined && formStateValidationResult.operatingSystemId !== null
                  ? (<FormHelperText>{formStateValidationResult.operatingSystemId}</FormHelperText>)
                  : null
              }
            </FormControl>
          </Box>
          <Box
            px={4}
            pb={2}
          >
            <FormControl fullWidth>
              <TextField
                label="Opis"
                helperText="Maksymalnie 4000 znaków."
                inputProps={{ maxLength: 4000 }}
                value={formState.description}
                multiline
                rows={4}
                onChange={onDescriptionChange}
              />
            </FormControl>
          </Box>
          <Box
            pb={3}
            pr={4}
            pt={1}
            textAlign="right"
          >
            <Button
              size="small"
              style={{ marginRight: '15px' }}
              variant="contained"
              onClick={onCancel}
            >
              Anuluj
            </Button>
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

export default CreateServerEditor;
