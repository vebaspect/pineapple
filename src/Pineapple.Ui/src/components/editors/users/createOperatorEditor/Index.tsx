import React, { useState } from 'react';
import { useHistory } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import Button from '@material-ui/core/Button';
import FormControl from '@material-ui/core/FormControl';
import Paper from '@material-ui/core/Paper';
import TextField from '@material-ui/core/TextField';

import SaveIcon from '@material-ui/icons/Save';

import {
  initialFormState,
  validateFormState,
} from './helpers';

import {
  VALIDATION_ERROR_TYPE__VALUE_REQUIRED,
} from '../../availableValidationErrorTypes';

const CreateOperatorEditor: React.VFC = () => {
  const history = useHistory();

  // Stan formularza.
  const [formState, setFormState] = useState(initialFormState());
  // Wynik walidacji stanu formularza.
  const [formStateValidationResult, setFormStateValidationResult] = useState(null);

  const onFullNameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      fullName: event.target.value,
    });
  };

  const onLoginChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      login: event.target.value,
    });
  };

  const onPhoneChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      phone: event.target.value,
    });
  };

  const onEmailChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      email: event.target.value,
    });
  };

  const onSave = async () => {
    const validationResult = validateFormState(formState);
    if (validationResult.isValid) {
      await fetch(
        `${window['env'].API_URL}/users/operators`,
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
          history.push('/operators');
        } else {
          return response.json();
        }
      })
      .then((data) => {
        switch (data.errorType) {
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
        Dodaj wdrożeniowca
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
                label="Imię i nazwisko"
                helperText={formStateValidationResult?.fullName || 'Maksymalnie 200 znaków.'}
                error={formStateValidationResult && formStateValidationResult.fullName !== undefined && formStateValidationResult.fullName !== null}
                value={formState.fullName}
                onChange={onFullNameChange}
              />
            </FormControl>
          </Box>
          <Box
            px={4}
            pb={2}
          >
            <FormControl fullWidth>
              <TextField
                label="Login"
                helperText={formStateValidationResult?.login || 'Maksymalnie 200 znaków.'}
                error={formStateValidationResult && formStateValidationResult.login !== undefined && formStateValidationResult.login !== null}
                value={formState.login}
                onChange={onLoginChange}
              />
            </FormControl>
          </Box>
          <Box
            px={4}
            pb={2}
          >
            <FormControl fullWidth>
              <TextField
                label="Telefon"
                helperText={formStateValidationResult?.phone || 'Maksymalnie 200 znaków.'}
                error={formStateValidationResult && formStateValidationResult.phone !== undefined && formStateValidationResult.phone !== null}
                value={formState.phone}
                onChange={onPhoneChange}
              />
            </FormControl>
          </Box>
          <Box
            px={4}
            pb={2}
          >
            <FormControl fullWidth>
              <TextField
                label="E-mail"
                helperText={formStateValidationResult?.email || 'Maksymalnie 200 znaków.'}
                error={formStateValidationResult && formStateValidationResult.email !== undefined && formStateValidationResult.email !== null}
                value={formState.email}
                onChange={onEmailChange}
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

export default CreateOperatorEditor;
