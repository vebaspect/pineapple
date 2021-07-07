import moment from 'moment-timezone';
import React, { useCallback, useEffect, useState } from 'react';
import { Link as RouterLink, useHistory, useParams } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import Button from '@material-ui/core/Button';
import Checkbox from '@material-ui/core/Checkbox';
import FormControl from '@material-ui/core/FormControl';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import FormHelperText from '@material-ui/core/FormHelperText';
import Link from '@material-ui/core/Link';
import Paper from '@material-ui/core/Paper';
import TextField from '@material-ui/core/TextField';

import { DateTimePicker } from '@material-ui/pickers';

import SaveIcon from '@material-ui/icons/Save';

import {
  convertFormStateToApiFormat,
  initialFormState,
  validateFormState,
} from './helpers';

import {
  VALIDATION_ERROR_TYPE__VALUE_REQUIRED,
} from '../../availableValidationErrorTypes';

const CreateComponentVersionEditor: React.VFC = () => {
  const history = useHistory();

  // Identyfikator produktu.
  const { productId } = useParams();
  // Identyfikator komponentu.
  const { componentId } = useParams();

  // Flaga określająca, czy produkt został pobrany z API.
  const [isProductFetched, setIsProductFetched] = useState(false);
  // Produkt.
  const [product, setProduct] = useState(null);

  // Flaga określająca, czy komponent został pobrany z API.
  const [isComponentFetched, setIsComponentFetched] = useState(false);
  // Komponent.
  const [component, setComponent] = useState(null);

  // Stan formularza.
  const [formState, setFormState] = useState(initialFormState());
  // Wynik walidacji stanu formularza.
  const [formStateValidationResult, setFormStateValidationResult] = useState(null);

  const fetchProduct = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/products/${productId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsProductFetched(true);
        setProduct(data);
      });
  }, [productId]);

  useEffect(() => {
    fetchProduct();
  }, [fetchProduct]);

  const fetchComponent = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/products/${productId}/components/${componentId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsComponentFetched(true);
        setComponent(data);
      });
  }, [productId, componentId]);

  useEffect(() => {
    fetchComponent();
  }, [fetchComponent]);

  const onReleaseDateChange = (value: moment.Moment) => {
    setFormState({
      ...formState,
      releaseDate: value.tz('Poland').format(),
    });
  };

  const onMajorChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      major: event.target.value,
    });
  };

  const onMinorChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      minor: event.target.value,
    });
  };

  const onPatchChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      patch: event.target.value,
    });
  };

  const onSuffixChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      suffix: event.target.value,
    });
  };

  const onIssueTrackingSystemTicketUrlChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      issueTrackingSystemTicketUrl: event.target.value,
    });
  };

  const onDescriptionChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      description: event.target.value,
    });
  };

  const onIsImportantChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      isImportant: event.target.checked,
    });
  };

  const onCancel = () => {
    history.push(`/products/${productId}/components/${componentId}/component-versions`);
  };

  const onSave = async () => {
    const validationResult = validateFormState(formState);
    if (validationResult.isValid) {
      await fetch(
        `${window['env'].API_URL}/products/${productId}/components/${componentId}/component-versions`,
        {
          body: JSON.stringify(convertFormStateToApiFormat(formState)),
          headers: {
            'Content-Type': 'application/json',
          },
          method: 'POST',
        },
      )
      .then((response) => {
        if (response.ok) {
          history.push(`/products/${productId}/components/${componentId}/component-versions`);
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
          to="/products"
        >
          Produkty
        </Link>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        <Link
          component={RouterLink}
          to={`/products/${productId}`}
        >
          {
            isProductFetched
              ? (
                <Box component="span">
                  {product?.name}
                </Box>)
              : ''
          }
        </Link>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        <Box component="span">
          Komponenty
        </Box>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        <Link
          component={RouterLink}
          to={`/products/${productId}/components/${componentId}`}
        >
          {
            isComponentFetched
              ? (
                <Box component="span">
                  {component?.name}
                </Box>)
              : ''
          }
        </Link>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        <Box component="span">
          Wersje
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
            <DateTimePicker
              format="LLL"
              variant="inline"
              label="Data wydania"
              helperText={formStateValidationResult?.releaseDate}
              error={formStateValidationResult && formStateValidationResult.releaseDate !== undefined && formStateValidationResult.releaseDate !== null}
              value={formState.releaseDate}
              onChange={onReleaseDateChange}
            />
          </Box>
          <Box
            px={4}
            pb={2}
          >
            <FormControl fullWidth>
              <TextField
                type="number"
                label="Major"
                helperText={formStateValidationResult?.major}
                error={formStateValidationResult && formStateValidationResult.major !== undefined && formStateValidationResult.major !== null}
                value={formState.major}
                onChange={onMajorChange}
              />
            </FormControl>
          </Box>
          <Box
            px={4}
            pb={2}
          >
            <FormControl fullWidth>
              <TextField
                type="number"
                label="Minor"
                helperText={formStateValidationResult?.minor}
                error={formStateValidationResult && formStateValidationResult.minor !== undefined && formStateValidationResult.minor !== null}
                value={formState.minor}
                onChange={onMinorChange}
              />
            </FormControl>
          </Box>
          <Box
            px={4}
            pb={2}
          >
            <FormControl fullWidth>
              <TextField
                type="number"
                label="Patch"
                helperText={formStateValidationResult?.patch}
                error={formStateValidationResult && formStateValidationResult.patch !== undefined && formStateValidationResult.patch !== null}
                value={formState.patch}
                onChange={onPatchChange}
              />
            </FormControl>
          </Box>
          <Box
            px={4}
            pb={2}
          >
            <FormControl fullWidth>
              <TextField
                label="Przyrostek"
                helperText={formStateValidationResult?.suffix || 'Maksymalnie 30 znaków.'}
                inputProps={{ maxLength: 30 }}
                error={formStateValidationResult && formStateValidationResult.suffix !== undefined && formStateValidationResult.suffix !== null}
                value={formState.suffix}
                onChange={onSuffixChange}
              />
            </FormControl>
          </Box>
          <Box
            px={4}
            pb={2}
          >
            <FormControl fullWidth>
              <TextField
                label="Zgłoszenie w systemie ITS"
                helperText="Adres URL | Maksymalnie 300 znaków."
                inputProps={{ maxLength: 300 }}
                value={formState.issueTrackingSystemTicketUrl}
                onChange={onIssueTrackingSystemTicketUrlChange}
              />
            </FormControl>
            <FormHelperText><strong>System ITS</strong> (ang. <em>Issue Tracking System</em>) - system obsługi zgłoszeń (np. <em>Jira</em>).</FormHelperText>
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
            px={4}
            pb={2}
          >
            <FormControlLabel
              label="Oznacz jako &quot;Ważną&quot;"
              control={
                <Checkbox
                  color="primary"
                  checked={formState.isImportant}
                  onChange={onIsImportantChange}
                />
              }
            />
            <FormHelperText><strong>Ważna</strong> wersja jest istotna z perspektywy rozwoju komponentu (np. zawiera krytyczne poprawki dotyczące bezpieczeństwa).</FormHelperText>
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

export default CreateComponentVersionEditor;
