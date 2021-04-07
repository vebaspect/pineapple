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

const CreateComponentEditor: React.VFC = () => {
  const history = useHistory();

  // Identyfikator produktu.
  const { productId } = useParams();

  // Stan formularza.
  const [formState, setFormState] = useState(initialFormState());
  // Wynik walidacji stanu formularza.
  const [formStateValidationResult, setFormStateValidationResult] = useState(null);

  // Flaga określająca, czy lista typów komponentów została pobrana z API.
  const [isComponentTypesFetched, setIsComponentTypesFetched] = useState(false);
  // Lista typów komponentów.
  const [componentTypes, setComponentTypes] = useState([]);

  const convertFetchedComponentTypes = (data) => {
    if (data && data.length > 0) {
      return data
        .filter((componentType) => !componentType.isDeleted)
        .sort((componentType1, componentType2) => componentType1.name.localeCompare(componentType2.name));
    }

    return [];
  };

  const fetchComponentTypes = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/configuration/component-types`)
      .then(response => response.json())
      .then(data => {
        setIsComponentTypesFetched(true);
        setComponentTypes(convertFetchedComponentTypes(data));
      });
  }, []);

  useEffect(() => {
    fetchComponentTypes();
  }, [fetchComponentTypes]);

  const onNameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      name: event.target.value,
    });
  };

  const onComponentTypeChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      componentTypeId: event.target.value,
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
        `${window['env'].API_URL}/products/${productId}/components`,
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
          history.push(`/products/${productId}`);
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
        Dodaj komponent
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
            <FormControl
              error={formStateValidationResult && formStateValidationResult.componentTypeId !== undefined && formStateValidationResult.componentTypeId !== null}
              fullWidth
            >
              <InputLabel id="component-type-label">Typ komponentu</InputLabel>
              <Select
                labelId="component-type-label"
                value={formState.componentTypeId}
                onChange={onComponentTypeChange}
              >
                {
                  isComponentTypesFetched && componentTypes.length > 0
                    ? (
                      componentTypes.map((componentType) => {
                        return (
                          <MenuItem
                            key={componentType.id}
                            value={componentType.id}
                          >
                            {componentType.name}
                            <Box
                              component="span"
                              color="text.secondary"
                              mx={0.5}
                            >
                              ({componentType.symbol})
                            </Box>
                          </MenuItem>
                        );
                      })
                    )
                    : []
                }
              </Select>
              {
                formStateValidationResult && formStateValidationResult.componentTypeId !== undefined && formStateValidationResult.componentTypeId !== null
                  ? (<FormHelperText>{formStateValidationResult.componentTypeId}</FormHelperText>)
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

export default CreateComponentEditor;
