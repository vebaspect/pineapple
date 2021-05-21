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

import SaveIcon from '@material-ui/icons/Save';

import {
  formatNumber,
} from '../../../../helpers/componentVersionHelpers';

import {
  initialFormState,
  validateFormState,
} from './helpers';

import {
  VALIDATION_ERROR_TYPE__VALUE_REQUIRED,
} from '../../availableValidationErrorTypes';

const UpdateServerComponentEditor: React.VFC = () => {
  const history = useHistory();

  // Identyfikator wdrożenia.
  const { implementationId } = useParams();
  // Identyfikator środowiska.
  const { environmentId } = useParams();
  // Identyfikator serwera.
  const { serverId } = useParams();
  // Identyfikator komponentu zainstalowanego na serwerze.
  const { serverComponentId } = useParams();

  // Flaga określająca, czy wdrożenie zostało pobrane z API.
  const [isImplementationFetched, setIsImplementationFetched] = useState(false);
  // Wdrożenie.
  const [implementation, setImplementation] = useState(null);

  // Flaga określająca, czy środowisko zostało pobrane z API.
  const [isEnvironmentFetched, setIsEnvironmentFetched] = useState(false);
  // Środowisko.
  const [environment, setEnvironment] = useState(null);

  // Flaga określająca, czy serwer został pobrany z API.
  const [isServerFetched, setIsServerFetched] = useState(false);
  // Serwer.
  const [server, setServer] = useState(null);

  // Stan formularza.
  const [formState, setFormState] = useState(initialFormState());
  // Wynik walidacji stanu formularza.
  const [formStateValidationResult, setFormStateValidationResult] = useState(null);

  // Flaga określająca, czy lista produktów została pobrana z API.
  const [isProductsFetched, setIsProductsFetched] = useState(false);
  // Lista produktów.
  const [products, setProducts] = useState([]);

  // Flaga określająca, czy lista komponentów została pobrana z API.
  const [isComponentsFetched, setIsComponentsFetched] = useState(false);
  // Lista komponentów.
  const [components, setComponents] = useState([]);

  // Flaga określająca, czy lista wersji komponentu została pobrana z API.
  const [isComponentVersionsFetched, setIsComponentVersionsFetched] = useState(false);
  // Lista wersji komponentu.
  const [componentVersions, setComponentVersions] = useState([]);

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

  const fetchServer = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/implementations/${implementationId}/environments/${environmentId}/servers/${serverId}`)
      .then((response) => response.json())
      .then((data) => {
        setIsServerFetched(true);
        setServer(data);
      });
  }, [implementationId, environmentId, serverId]);

  useEffect(() => {
    fetchServer();
  }, [fetchServer]);

  const fetchInstalledComponent = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/implementations/${implementationId}/environments/${environmentId}/servers/${serverId}/components/${serverComponentId}`,)
      .then((response) => response.json())
      .then((data) => {
        setFormState({
          productId: data.productId,
          componentId: data.componentId,
          componentVersionId: data.componentVersionId,
        });
      });
  }, [implementationId, environmentId, serverId, serverComponentId]);

  useEffect(() => {
    fetchInstalledComponent();
  }, [fetchInstalledComponent]);

  const convertFetchedProducts = (data) => {
    if (data && data.length > 0) {
      return data
        .filter((product) => !product.isDeleted)
        .sort((product1, product2) => product1.name.localeCompare(product2.name));
    }

    return [];
  };

  const convertFetchedComponents = (data) => {
    if (data && data.length > 0) {
      return data
        .filter((component) => !component.isDeleted)
        .sort((component1, component2) => component1.name.localeCompare(component2.name));
    }

    return [];
  };

  const convertFetchedComponentVersions = (data) => {
    if (data && data.length > 0) {
      return data
        .filter((componentVersion) => !componentVersion.isDeleted);
        // TODO Sortowanie.
    }

    return [];
  };

  const fetchProducts = useCallback(async () => {
    await fetch(`${window['env'].API_URL}/products`)
      .then((response) => response.json())
      .then((data) => {
        setIsProductsFetched(true);
        setProducts(convertFetchedProducts(data));
      });
  }, []);

  useEffect(() => {
    fetchProducts();
  }, [fetchProducts]);

  const fetchComponents = useCallback(async () => {
    if (formState.productId) {
      await fetch(`${window['env'].API_URL}/products/${formState.productId}/components`)
        .then((response) => response.json())
        .then((data) => {
          setIsComponentsFetched(true);
          setComponents(convertFetchedComponents(data));
        });
    }
  }, [formState.productId]);

  useEffect(() => {
    fetchComponents();
  }, [fetchComponents]);

  const fetchComponentVersions = useCallback(async () => {
    if (formState.productId && formState.componentId) {
      await fetch(`${window['env'].API_URL}/products/${formState.productId}/components/${formState.componentId}/component-versions`)
        .then((response) => response.json())
        .then((data) => {
          setIsComponentVersionsFetched(true);
          setComponentVersions(convertFetchedComponentVersions(data));
        });
    }
  }, [formState.productId, formState.componentId]);

  useEffect(() => {
    fetchComponentVersions();
  }, [fetchComponentVersions]);

  const onComponentVersionChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormState({
      ...formState,
      componentVersionId: event.target.value,
    });
  };

  const onCancel = () => {
    history.push(`/implementations/${implementationId}/environments/${environmentId}/servers/${serverId}`);
  };

  const onSave = async () => {
    const validationResult = validateFormState(formState);
    if (validationResult.isValid) {
      await fetch(
        `${window['env'].API_URL}/implementations/${implementationId}/environments/${environmentId}/servers/${serverId}/components/${serverComponentId}`,
        {
          body: JSON.stringify(formState),
          headers: {
            'Content-Type': 'application/json',
          },
          method: 'PATCH',
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
        <Link
          component={RouterLink}
          to={`/implementations/${implementationId}/environments/${environmentId}/servers/${serverId}`}
        >
          {
            isServerFetched
              ? (
                <Box component="span">
                  {server?.name}
                </Box>)
              : ''
          }
        </Link>
        <Box component="span" style={{ paddingLeft: '5px', paddingRight: '5px' }}>/</Box>
        <Box component="span">
          Zaktualizuj komponent
        </Box>
      </Box>
      <Box>
        <Paper>
          <Box
            px={4}
            pb={2}
            pt={4}
          >
            <FormControl
              disabled
              fullWidth
            >
              <InputLabel id="product-label">Produkt</InputLabel>
              <Select
                labelId="product-label"
                value={formState.productId}
              >
                {
                  isProductsFetched && products.length > 0
                    ? (
                      products.map((product) => {
                        return (
                          <MenuItem
                            key={product.id}
                            value={product.id}
                          >
                            {product.name}
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
            <FormControl
              disabled
              fullWidth
            >
              <InputLabel id="component-label">Komponent</InputLabel>
              <Select
                labelId="component-label"
                value={formState.componentId}
              >
                {
                  isComponentsFetched && components.length > 0
                    ? (
                      components.map((component) => {
                        return (
                          <MenuItem
                            key={component.id}
                            value={component.id}
                          >
                            {component.name}
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
            <FormControl
              error={formStateValidationResult && formStateValidationResult.componentVersionId !== undefined && formStateValidationResult.componentVersionId !== null}
              fullWidth
            >
              <InputLabel id="component-version-label">Wersja</InputLabel>
              <Select
                labelId="component-version-label"
                value={formState.componentVersionId}
                onChange={onComponentVersionChange}
              >
                {
                  isComponentVersionsFetched && componentVersions.length > 0
                    ? (
                      componentVersions.map((componentVersion) => {
                        return (
                          <MenuItem
                            key={componentVersion.id}
                            value={componentVersion.id}
                          >
                            {formatNumber(componentVersion.major, componentVersion.minor, componentVersion.patch, componentVersion.suffix)}
                          </MenuItem>
                        );
                      })
                    )
                    : []
                }
              </Select>
              {
                formStateValidationResult && formStateValidationResult.componentVersionId !== undefined && formStateValidationResult.componentVersionId !== null
                  ? (<FormHelperText>{formStateValidationResult.componentVersionId}</FormHelperText>)
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

export default UpdateServerComponentEditor;
