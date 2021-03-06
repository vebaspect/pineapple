import React, { useCallback, useEffect, useState } from 'react';
import { Link as RouterLink, useHistory } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import Button from '@material-ui/core/Button';
import FormControl from '@material-ui/core/FormControl';
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

const CreateImplementationEditor: React.VFC = () => {
  const history = useHistory();

  // Stan formularza.
  const [formState, setFormState] = useState(initialFormState());
  // Wynik walidacji stanu formularza.
  const [formStateValidationResult, setFormStateValidationResult] = useState(null);

  // Flaga określająca, czy lista menedżerów została pobrana z API.
  const [isManagersFetched, setIsManagersFetched] = useState(false);
  // Lista menedżerów.
  const [managers, setManagers] = useState([]);

  const convertFetchedManagers = (data) => {
    if (data && data.length > 0) {
      return data
        .filter((manager) => !manager.isDeleted)
        .sort((manager1, manager2) => manager1.fullName.localeCompare(manager2.fullName));
    }

    return [];
  };

  const fetchManagers = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/users/managers`)
      .then((response) => response.json())
      .then((data) => {
        setIsManagersFetched(true);
        setManagers(convertFetchedManagers(data));
      });
  }, []);

  useEffect(() => {
    fetchManagers();
  }, [fetchManagers]);

  const onNameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      name: event.target.value,
    });
  };

  const onManagerChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      managerId: event.target.value,
    });
  };

  const onDescriptionChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      description: event.target.value,
    });
  };

  const onCancel = () => {
    history.push('/implementations');
  };

  const onSave = async () => {
    const validationResult = validateFormState(formState);
    if (validationResult.isValid) {
      await fetch(
        `${window['env'].API_URL}/implementations`,
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
          history.push('/implementations');
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
        Dodaj
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
              <InputLabel id="manager-label">Menedżer</InputLabel>
              <Select
                labelId="manager-label"
                value={formState.managerId}
                onChange={onManagerChange}
              >
                {
                  isManagersFetched && managers.length > 0
                    ? (
                      managers.map((manager) => {
                        return (
                          <MenuItem
                            key={manager.id}
                            value={manager.id}
                          >
                            {manager.fullName}
                            <Box
                              component="span"
                              color="text.secondary"
                              mx={0.5}
                            >
                              ({manager.login})
                            </Box>
                          </MenuItem>
                        );
                      })
                    )
                    : []
                }
              </Select>
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

export default CreateImplementationEditor;
