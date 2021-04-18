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
import TextField from '@material-ui/core/TextField';

import SaveIcon from '@material-ui/icons/Save';

import {
  initialFormState,
  validateFormState,
} from './helpers';

import {
  VALIDATION_ERROR_TYPE__VALUE_REQUIRED,
} from '../../availableValidationErrorTypes';

const CreateEnvironmentEditor: React.VFC = () => {
  const history = useHistory();

  // Identyfikator wdrożenia.
  const { implementationId } = useParams();

  // Stan formularza.
  const [formState, setFormState] = useState(initialFormState());
  // Wynik walidacji stanu formularza.
  const [formStateValidationResult, setFormStateValidationResult] = useState(null);

  // Flaga określająca, czy lista wdrożeniowców została pobrana z API.
  const [isOperatorsFetched, setIsOperatorsFetched] = useState(false);
  // Lista wdrożeniowców.
  const [operators, setOperators] = useState([]);

  const convertFetchedOperators = (data) => {
    if (data && data.length > 0) {
      return data
        .filter((operator) => !operator.isDeleted)
        .sort((operator1, operator2) => operator1.fullName.localeCompare(operator2.fullName));
    }

    return [];
  };

  const fetchOperators = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/users/operators`)
      .then((response) => response.json())
      .then((data) => {
        setIsOperatorsFetched(true);
        setOperators(convertFetchedOperators(data));
      });
  }, []);

  useEffect(() => {
    fetchOperators();
  }, [fetchOperators]);

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

  const onOperatorChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      operatorId: event.target.value,
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
        `${window['env'].API_URL}/implementations/${implementationId}/environments`,
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
          history.push(`/implementations/${implementationId}`);
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
        Dodaj środowisko
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
                label="Symbol"
                helperText={formStateValidationResult?.symbol || 'Maksymalnie 200 znaków.'}
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
            <FormControl
              error={formStateValidationResult && formStateValidationResult.operatorId !== undefined && formStateValidationResult.operatorId !== null}
              fullWidth
            >
              <InputLabel id="operator-label">Wdrożeniowiec</InputLabel>
              <Select
                labelId="operator-label"
                value={formState.operatorId}
                onChange={onOperatorChange}
              >
                {
                  isOperatorsFetched && operators.length > 0
                    ? (
                      operators.map((operator) => {
                        return (
                          <MenuItem
                            key={operator.id}
                            value={operator.id}
                          >
                            {operator.fullName}
                            <Box
                              component="span"
                              color="text.secondary"
                              mx={0.5}
                            >
                              ({operator.login})
                            </Box>
                          </MenuItem>
                        );
                      })
                    )
                    : []
                }
              </Select>
              {
                formStateValidationResult && formStateValidationResult.operatorId !== undefined && formStateValidationResult.operatorId !== null
                  ? (<FormHelperText>{formStateValidationResult.operatorId}</FormHelperText>)
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

export default CreateEnvironmentEditor;
