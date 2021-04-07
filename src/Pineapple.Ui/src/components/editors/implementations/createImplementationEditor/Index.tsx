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

const CreateImplementationEditor: React.VFC = () => {
  const history = useHistory();

  // Stan formularza.
  const [formState, setFormState] = useState(initialFormState());
  // Wynik walidacji stanu formularza.
  const [formStateValidationResult, setFormStateValidationResult] = useState(null);

  const onNameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      name: event.target.value,
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
        Dodaj wdrożenie
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
                label="Opis"
                helperText="Maksymalnie 4000 znaków."
                value={formState.description}
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
