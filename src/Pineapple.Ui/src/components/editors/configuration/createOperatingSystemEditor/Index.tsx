import React, { useState } from 'react';
import { useHistory } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import Button from '@material-ui/core/Button';
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

const CreateOperatingSystemEditor: React.VFC = () => {
  // Stan formularza.
  const [formState, setFormState] = useState(initialFormState());
  // Wynik walidacji stanu formularza.
  const [formStateValidationResult, setFormStateValidationResult] = useState(null);

  const history = useHistory();

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

  const onDescriptionChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      description: event.target.value,
    });
  };

  const onSave = async () => {
    const validationResult = validateFormState(formState);
    if (validationResult.isValid) {
      await fetch(
        `${window['env'].API_URL}/configuration/operating-systems`,
        {
          body: JSON.stringify(formState),
          headers: {
            'Content-Type': 'application/json',
          },
          method: 'POST',
        },
      )
      .then(response => {
        if (response.ok) {
          history.push('/operating-systems');
        } else {
          return response.json();
        }
      })
      .then(data => {
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
        Dodaj system operacyjny
      </Box>
      <Box>
        <Paper>
          <Box
            px={4}
            pb={2}
            pt={4}
          >
            <TextField
              fullWidth
              label="Nazwa"
              helperText={formStateValidationResult?.name || 'Maksymalnie 200 znaków.'}
              error={formStateValidationResult && formStateValidationResult.name !== undefined && formStateValidationResult.name !== null}
              value={formState.name}
              onChange={onNameChange}
            />
          </Box>
          <Box
            px={4}
            pb={2}
          >
            <TextField
              fullWidth
              label="Symbol"
              helperText={formStateValidationResult?.symbol || 'Maksymalnie 200 znaków.'}
              error={formStateValidationResult && formStateValidationResult.symbol !== undefined && formStateValidationResult.symbol !== null}
              value={formState.symbol}
              onChange={onSymbolChange}
            />
          </Box>
          <Box
            px={4}
            pb={2}
          >
            <TextField
              fullWidth
              label="Opis"
              helperText="Maksymalnie 4000 znaków."
              value={formState.description}
              onChange={onDescriptionChange}
            />
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

export default CreateOperatingSystemEditor;
