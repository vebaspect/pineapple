import React from 'react';
import { Link as RouterLink } from 'react-router-dom';

import {
  createStyles,
  makeStyles,
} from '@material-ui/core/styles';

import Box from '@material-ui/core/Box';
import Link from '@material-ui/core/Link';

import {
  KIND__PATCH,
} from '../../../helpers/componentVersionConstants';

import {
  LOG_TYPE__COMPONENT,
  LOG_TYPE__COMPONENT_TYPE,
  LOG_TYPE__COMPONENT_VERSION,
  LOG_TYPE__ENVIRONMENT,
  LOG_TYPE__IMPLEMENTATION,
  LOG_TYPE__OPERATING_SYSTEM,
  LOG_TYPE__PRODUCT,
  LOG_TYPE__SERVER,
  LOG_TYPE__SERVER_COMPONENT,
  LOG_TYPE__SERVER_SOFTWARE_APPLICATION,
  LOG_TYPE__SOFTWARE_APPLICATION,
  LOG_TYPE__USER,
  LOG_CATEGORY__CREATE_ENTITY,
  LOG_CATEGORY__MODIFY_ENTITY,
  LOG_CATEGORY__REMOVE_ENTITY,
} from './constants';

import {
  translateComponentVersionKind,
} from './helpers';

import {
  TextProps,
} from './interfaces';

const useStyles = makeStyles(() =>
  createStyles({
    component: {
      color: '#3f51b5',
    },
    componentType: {
      color: '#ffac33',
    },
    componentVersion: {
      color: '#6573c3',
    },
    environment: {
      color: '#009688',
    },
    implementation: {
      color: '#00695f',
    },
    operatingSystem: {
      color: '#ffac33',
    },
    product: {
      color: '#2c387e',
    },
    server: {
      color: '#33ab9f',
    },
    softwareApplication: {
      color: '#ffac33',
    },
    user: {
      color: '#af52bf',
    },
    owner: {
      color: '#90a4ae',
    },
  }),
);

const Text: React.FC<TextProps> = ({ type, category, ownerId, ownerFullName, entity, parentEntities }: TextProps) => {
  const styles = useStyles();

  switch (type) {
    case LOG_TYPE__COMPONENT: {
      switch (category) {
        case LOG_CATEGORY__CREATE_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.owner}
                  component={RouterLink}
                  to={`/users/${ownerId}`}
                >
                  {`«${ownerFullName}»`}
                </Link>
              </Box>
              dodał komponent
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.component}
                  component={RouterLink}
                  to={`/products/${parentEntities[0].id}/components/${entity.id}`}
                >
                  {`«${entity.name}»`}
                </Link>
              </Box>
              do produktu
              <Box
                component="span"
                ml={0.5}
              >
                <Link
                  className={styles.product}
                  component={RouterLink}
                  to={`/products/${parentEntities[0].id}`}
                >
                  {`«${parentEntities[0].name}»`}
                </Link>
              </Box>
              .
            </>
          );
        case LOG_CATEGORY__REMOVE_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.owner}
                  component={RouterLink}
                  to={`/users/${ownerId}`}
                >
                  {`«${ownerFullName}»`}
                </Link>
              </Box>
              usunął komponent
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.component}
                  component={RouterLink}
                  to={`/products/${parentEntities[0].id}/components/${entity.id}`}
                >
                  {`«${entity.name}»`}
                </Link>
              </Box>
              z produktu
              <Box
                component="span"
                ml={0.5}
              >
                <Link
                  className={styles.product}
                  component={RouterLink}
                  to={`/products/${parentEntities[0].id}`}
                >
                  {`«${parentEntities[0].name}»`}
                </Link>
              </Box>
              .
            </>
          );
        default:
          return null;
      }
    }
    case LOG_TYPE__COMPONENT_TYPE: {
      switch (category) {
        case LOG_CATEGORY__CREATE_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.owner}
                  component={RouterLink}
                  to={`/users/${ownerId}`}
                >
                  {`«${ownerFullName}»`}
                </Link>
              </Box>
              dodał typ komponentu
              <Box
                component="span"
                ml={0.5}
              >
                <Link
                  className={styles.componentType}
                  component={RouterLink}
                  to={`/configuration/component-types/${entity.id}`}
                >
                  {`«${entity.name}»`}
                </Link>
              </Box>
              .
            </>
          );
        case LOG_CATEGORY__REMOVE_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.owner}
                  component={RouterLink}
                  to={`/users/${ownerId}`}
                >
                  {`«${ownerFullName}»`}
                </Link>
              </Box>
              usunął typ komponentu
              <Box
                component="span"
                ml={0.5}
              >
                <Link
                  className={styles.componentType}
                  component={RouterLink}
                  to={`/configuration/component-types/${entity.id}`}
                >
                  {`«${entity.name}»`}
                </Link>
              </Box>
              .
            </>
          );
        default:
          return null;
      }
    }
    case LOG_TYPE__COMPONENT_VERSION: {
      switch (category) {
        case LOG_CATEGORY__CREATE_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.owner}
                  component={RouterLink}
                  to={`/users/${ownerId}`}
                >
                  {`«${ownerFullName}»`}
                </Link>
              </Box>
              wydał {translateComponentVersionKind(entity.details.componentVersion.kind)}
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.componentVersion}
                  component={RouterLink}
                  to={`/products/${parentEntities[1].id}/components/${parentEntities[0].id}/component-versions/${entity.id}`}
                >
                  {`«${entity.name}»`}
                </Link>
              </Box>
              {entity.details.componentVersion.kind === KIND__PATCH ? 'dla komponentu' : 'komponentu'}
              <Box
                component="span"
                ml={0.5}
              >
                <Link
                  className={styles.component}
                  component={RouterLink}
                  to={`/products/${parentEntities[1].id}/components/${parentEntities[0].id}`}
                >
                  {`«`}
                  <Box
                    component="span"
                    style={{ fontSize: '0.75rem' }}
                  >
                    {parentEntities[1].name}
                  </Box>
                  <Box
                    component="span"
                    mx={0.25}
                  >
                    |
                  </Box>
                  {`${parentEntities[0].name}`}
                  {`»`}
                </Link>
              </Box>
              .
            </>
          );
        case LOG_CATEGORY__REMOVE_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.owner}
                  component={RouterLink}
                  to={`/users/${ownerId}`}
                >
                  {`«${ownerFullName}»`}
                </Link>
              </Box>
              usunął {translateComponentVersionKind(entity.details.componentVersion.kind)}
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.componentVersion}
                  component={RouterLink}
                  to={`/products/${parentEntities[1].id}/components/${parentEntities[0].id}/component-versions/${entity.id}`}
                >
                  {`«${entity.name}»`}
                </Link>
              </Box>
              {entity.details.componentVersion.kind === KIND__PATCH ? 'dla komponentu' : 'komponentu'}
              <Box
                component="span"
                ml={0.5}
              >
                <Link
                  className={styles.component}
                  component={RouterLink}
                  to={`/products/${parentEntities[1].id}/components/${parentEntities[0].id}`}
                >
                  {`«`}
                  <Box
                    component="span"
                    style={{ fontSize: '0.75rem' }}
                  >
                    {parentEntities[1].name}
                  </Box>
                  <Box
                    component="span"
                    mx={0.25}
                  >
                    |
                  </Box>
                  {`${parentEntities[0].name}`}
                  {`»`}
                </Link>
              </Box>
              .
            </>
          );
        default:
          return null;
      }
    }
    case LOG_TYPE__ENVIRONMENT: {
      switch (category) {
        case LOG_CATEGORY__CREATE_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.owner}
                  component={RouterLink}
                  to={`/users/${ownerId}`}
                >
                  {`«${ownerFullName}»`}
                </Link>
              </Box>
              dodał środowisko
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.environment}
                  component={RouterLink}
                  to={`/implementations/${parentEntities[0].id}/environments/${entity.id}`}
                >
                  {`«${entity.name}»`}
                </Link>
              </Box>
              do wdrożenia
              <Box
                component="span"
                ml={0.5}
              >
                <Link
                  className={styles.implementation}
                  component={RouterLink}
                  to={`/implementations/${parentEntities[0].id}`}
                >
                  {`«${parentEntities[0].name}»`}
                </Link>
              </Box>
              .
            </>
          );
        case LOG_CATEGORY__REMOVE_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.owner}
                  component={RouterLink}
                  to={`/users/${ownerId}`}
                >
                  {`«${ownerFullName}»`}
                </Link>
              </Box>
              usunął środowisko
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.environment}
                  component={RouterLink}
                  to={`/implementations/${parentEntities[0].id}/environments/${entity.id}`}
                >
                  {`«${entity.name}»`}
                </Link>
              </Box>
              z wdrożenia
              <Box
                component="span"
                ml={0.5}
              >
                <Link
                  className={styles.implementation}
                  component={RouterLink}
                  to={`/implementations/${parentEntities[0].id}`}
                >
                  {`«${parentEntities[0].name}»`}
                </Link>
              </Box>
              .
            </>
          );
        default:
          return null;
      }
    }
    case LOG_TYPE__IMPLEMENTATION: {
      switch (category) {
        case LOG_CATEGORY__CREATE_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.owner}
                  component={RouterLink}
                  to={`/users/${ownerId}`}
                >
                  {`«${ownerFullName}»`}
                </Link>
              </Box>
              dodał wdrożenie
              <Box
                component="span"
                ml={0.5}
              >
                <Link
                  className={styles.implementation}
                  component={RouterLink}
                  to={`/implementations/${entity.id}`}
                >
                  {`«${entity.name}»`}
                </Link>
              </Box>
              .
            </>
          );
        case LOG_CATEGORY__REMOVE_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.owner}
                  component={RouterLink}
                  to={`/users/${ownerId}`}
                >
                  {`«${ownerFullName}»`}
                </Link>
              </Box>
              usunął wdrożenie
              <Box
                component="span"
                ml={0.5}
              >
                <Link
                  className={styles.implementation}
                  component={RouterLink}
                  to={`/implementations/${entity.id}`}
                >
                  {`«${entity.name}»`}
                </Link>
              </Box>
              .
            </>
          );
        default:
          return null;
      }
    }
    case LOG_TYPE__OPERATING_SYSTEM: {
      switch (category) {
        case LOG_CATEGORY__CREATE_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.owner}
                  component={RouterLink}
                  to={`/users/${ownerId}`}
                >
                  {`«${ownerFullName}»`}
                </Link>
              </Box>
              dodał system operacyjny
              <Box
                component="span"
                ml={0.5}
              >
                <Link
                  className={styles.operatingSystem}
                  component={RouterLink}
                  to={`/configuration/operating-systems/${entity.id}`}
                >
                  {`«${entity.name}»`}
                </Link>
              </Box>
              .
            </>
          );
        case LOG_CATEGORY__REMOVE_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.owner}
                  component={RouterLink}
                  to={`/users/${ownerId}`}
                >
                  {`«${ownerFullName}»`}
                </Link>
              </Box>
              usunął system operacyjny
              <Box
                component="span"
                ml={0.5}
              >
                <Link
                  className={styles.operatingSystem}
                  component={RouterLink}
                  to={`/configuration/operating-systems/${entity.id}`}
                >
                  {`«${entity.name}»`}
                </Link>
              </Box>
              .
            </>
          );
        default:
          return null;
      }
    }
    case LOG_TYPE__PRODUCT: {
      switch (category) {
        case LOG_CATEGORY__CREATE_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.owner}
                  component={RouterLink}
                  to={`/users/${ownerId}`}
                >
                  {`«${ownerFullName}»`}
                </Link>
              </Box>
              dodał produkt
              <Box
                component="span"
                ml={0.5}
              >
                <Link
                  className={styles.product}
                  component={RouterLink}
                  to={`/products/${entity.id}`}
                >
                  {`«${entity.name}»`}
                </Link>
              </Box>
              .
            </>
          );
        case LOG_CATEGORY__REMOVE_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.owner}
                  component={RouterLink}
                  to={`/users/${ownerId}`}
                >
                  {`«${ownerFullName}»`}
                </Link>
              </Box>
              usunął produkt
              <Box
                component="span"
                ml={0.5}
              >
                <Link
                  className={styles.product}
                  component={RouterLink}
                  to={`/products/${entity.id}`}
                >
                  {`«${entity.name}»`}
                </Link>
              </Box>
              .
            </>
          );
        default:
          return null;
      }
    }
    case LOG_TYPE__SERVER: {
      switch (category) {
        case LOG_CATEGORY__CREATE_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.owner}
                  component={RouterLink}
                  to={`/users/${ownerId}`}
                >
                  {`«${ownerFullName}»`}
                </Link>
              </Box>
              dodał serwer
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.server}
                  component={RouterLink}
                  to={`/implementations/${parentEntities[1].id}/environments/${parentEntities[0].id}/servers/${entity.id}`}
                >
                  {`«${entity.name}»`}
                </Link>
              </Box>
              do środowiska
              <Box
                component="span"
                ml={0.5}
              >
                <Link
                  className={styles.environment}
                  component={RouterLink}
                  to={`/implementations/${parentEntities[1].id}/environments/${parentEntities[0].id}`}
                >
                  {`«${parentEntities[0].name}»`}
                </Link>
              </Box>
              .
            </>
          );
        case LOG_CATEGORY__REMOVE_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.owner}
                  component={RouterLink}
                  to={`/users/${ownerId}`}
                >
                  {`«${ownerFullName}»`}
                </Link>
              </Box>
              usunął serwer
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.server}
                  component={RouterLink}
                  to={`/implementations/${parentEntities[1].id}/environments/${parentEntities[0].id}/servers/${entity.id}`}
                >
                  {`«${entity.name}»`}
                </Link>
              </Box>
              ze środowiska
              <Box
                component="span"
                ml={0.5}
              >
                <Link
                  className={styles.environment}
                  component={RouterLink}
                  to={`/implementations/${parentEntities[1].id}/environments/${parentEntities[0].id}`}
                >
                  {`«${parentEntities[0].name}»`}
                </Link>
              </Box>
              .
            </>
          );
        default:
          return null;
      }
    }
    case LOG_TYPE__SERVER_COMPONENT: {
      switch (category) {
        case LOG_CATEGORY__CREATE_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.owner}
                  component={RouterLink}
                  to={`/users/${ownerId}`}
                >
                  {`«${ownerFullName}»`}
                </Link>
              </Box>
              zainstalował komponent
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.component}
                  component={RouterLink}
                  to={`/products/${entity.details.serverComponent.productId}/components/${entity.details.serverComponent.componentId}`}
                >
                  {`«`}
                  <Box
                    component="span"
                    style={{ fontSize: '0.75rem' }}
                  >
                    {entity.details.serverComponent.productName}
                  </Box>
                  <Box
                    component="span"
                    mx={0.25}
                  >
                    |
                  </Box>
                  {`${entity.details.serverComponent.componentName}`}
                  {`»`}
                </Link>
              </Box>
              w wersji
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.componentVersion}
                  component={RouterLink}
                  to={`/products/${entity.details.serverComponent.productId}/components/${entity.details.serverComponent.componentId}/component-versions/${entity.details.serverComponent.componentVersionId}`}
                >
                  {`«${entity.details.serverComponent.componentVersionNumber}»`}
                </Link>
              </Box>
              na serwerze
              <Box
                component="span"
                ml={0.5}
              >
                <Link
                  className={styles.server}
                  component={RouterLink}
                  to={`/implementations/${parentEntities[1].id}/environments/${parentEntities[0].id}/servers/${entity.id}`}
                >
                  {`«`}
                  <Box
                    component="span"
                    style={{ fontSize: '0.75rem' }}
                  >
                    {`${parentEntities[1].name}/${parentEntities[0].name}`}
                  </Box>
                  <Box component="span" mx={0.25}>|</Box>
                  {entity.name}
                  {`»`}
                </Link>
              </Box>
              .
            </>
          );
        case LOG_CATEGORY__MODIFY_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.owner}
                  component={RouterLink}
                  to={`/users/${ownerId}`}
                >
                  {`«${ownerFullName}»`}
                </Link>
              </Box>
              zaktualizował komponent
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.component}
                  component={RouterLink}
                  to={`/products/${entity.details.serverComponent.productId}/components/${entity.details.serverComponent.componentId}`}
                >
                  {`«`}
                  <Box
                    component="span"
                    style={{ fontSize: '0.75rem' }}
                  >
                    {entity.details.serverComponent.productName}
                  </Box>
                  <Box
                    component="span"
                    mx={0.25}
                  >
                    |
                  </Box>
                  {`${entity.details.serverComponent.componentName}`}
                  {`»`}
                </Link>
              </Box>
              do wersji
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.componentVersion}
                  component={RouterLink}
                  to={`/products/${entity.details.serverComponent.productId}/components/${entity.details.serverComponent.componentId}/component-versions/${entity.details.serverComponent.componentVersionId}`}
                >
                  {`«${entity.details.serverComponent.componentVersionNumber}»`}
                </Link>
              </Box>
              na serwerze
              <Box
                component="span"
                ml={0.5}
              >
                <Link
                  className={styles.server}
                  component={RouterLink}
                  to={`/implementations/${parentEntities[1].id}/environments/${parentEntities[0].id}/servers/${entity.id}`}
                >
                  {`«`}
                  <Box
                    component="span"
                    style={{ fontSize: '0.75rem' }}
                  >
                    {`${parentEntities[1].name}/${parentEntities[0].name}`}
                  </Box>
                  <Box component="span" mx={0.25}>|</Box>
                  {entity.name}
                  {`»`}
                </Link>
              </Box>
              .
            </>
          );
        case LOG_CATEGORY__REMOVE_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.owner}
                  component={RouterLink}
                  to={`/users/${ownerId}`}
                >
                  {`«${ownerFullName}»`}
                </Link>
              </Box>
              odinstalował komponent
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.component}
                  component={RouterLink}
                  to={`/products/${entity.details.serverComponent.productId}/components/${entity.details.serverComponent.componentId}`}
                >
                  {`«`}
                  <Box
                    component="span"
                    style={{ fontSize: '0.75rem' }}
                  >
                    {entity.details.serverComponent.productName}
                  </Box>
                  <Box
                    component="span"
                    mx={0.25}
                  >
                    |
                  </Box>
                  {`${entity.details.serverComponent.componentName}`}
                  {`»`}
                </Link>
              </Box>
              z serwera
              <Box
                component="span"
                ml={0.5}
              >
                <Link
                  className={styles.server}
                  component={RouterLink}
                  to={`/implementations/${parentEntities[1].id}/environments/${parentEntities[0].id}/servers/${entity.id}`}
                >
                  {`«`}
                  <Box
                    component="span"
                    style={{ fontSize: '0.75rem' }}
                  >
                    {`${parentEntities[1].name}/${parentEntities[0].name}`}
                  </Box>
                  <Box component="span" mx={0.25}>|</Box>
                  {entity.name}
                  {`»`}
                </Link>
              </Box>
              .
            </>
          );
        default:
          return null;
      }
    }
    case LOG_TYPE__SERVER_SOFTWARE_APPLICATION: {
      switch (category) {
        case LOG_CATEGORY__CREATE_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.owner}
                  component={RouterLink}
                  to={`/users/${ownerId}`}
                >
                  {`«${ownerFullName}»`}
                </Link>
              </Box>
              zainstalował oprogramowanie
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.softwareApplication}
                  component={RouterLink}
                  to={`/configuration/software-applications/${entity.details.serverSoftwareApplication.softwareApplicationId}`}
                >
                  {`«${entity.details.serverSoftwareApplication.softwareApplicationName}»`}
                </Link>
              </Box>
              na serwerze
              <Box
                component="span"
                ml={0.5}
              >
                <Link
                  className={styles.server}
                  component={RouterLink}
                  to={`/implementations/${parentEntities[1].id}/environments/${parentEntities[0].id}/servers/${entity.id}`}
                >
                  {`«`}
                  <Box
                    component="span"
                    style={{ fontSize: '0.75rem' }}
                  >
                    {`${parentEntities[1].name}/${parentEntities[0].name}`}
                  </Box>
                  <Box component="span" mx={0.25}>|</Box>
                  {entity.name}
                  {`»`}
                </Link>
              </Box>
              .
            </>
          );
        case LOG_CATEGORY__REMOVE_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.owner}
                  component={RouterLink}
                  to={`/users/${ownerId}`}
                >
                  {`«${ownerFullName}»`}
                </Link>
              </Box>
              odinstalował oprogramowanie
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.softwareApplication}
                  component={RouterLink}
                  to={`/configuration/software-applications/${entity.details.serverSoftwareApplication.softwareApplicationId}`}
                >
                  {`«${entity.details.serverSoftwareApplication.softwareApplicationName}»`}
                </Link>
              </Box>
              z serwera
              <Box
                component="span"
                ml={0.5}
              >
                <Link
                  className={styles.server}
                  component={RouterLink}
                  to={`/implementations/${parentEntities[1].id}/environments/${parentEntities[0].id}/servers/${entity.id}`}
                >
                  {`«`}
                  <Box
                    component="span"
                    style={{ fontSize: '0.75rem' }}
                  >
                    {`${parentEntities[1].name}/${parentEntities[0].name}`}
                  </Box>
                  <Box component="span" mx={0.25}>|</Box>
                  {entity.name}
                  {`»`}
                </Link>
              </Box>
              .
            </>
          );
        default:
          return null;
      }
    }
    case LOG_TYPE__SOFTWARE_APPLICATION: {
      switch (category) {
        case LOG_CATEGORY__CREATE_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.owner}
                  component={RouterLink}
                  to={`/users/${ownerId}`}
                >
                  {`«${ownerFullName}»`}
                </Link>
              </Box>
              dodał oprogramowanie
              <Box
                component="span"
                ml={0.5}
              >
                <Link
                  className={styles.softwareApplication}
                  component={RouterLink}
                  to={`/configuration/software-applications/${entity.id}`}
                >
                  {`«${entity.name}»`}
                </Link>
              </Box>
              .
            </>
          );
        case LOG_CATEGORY__REMOVE_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.owner}
                  component={RouterLink}
                  to={`/users/${ownerId}`}
                >
                  {`«${ownerFullName}»`}
                </Link>
              </Box>
              usunął oprogramowanie
              <Box
                component="span"
                ml={0.5}
              >
                <Link
                  className={styles.softwareApplication}
                  component={RouterLink}
                  to={`/configuration/software-applications/${entity.id}`}
                >
                  {`«${entity.name}»`}
                </Link>
              </Box>
              .
            </>
          );
        default:
          return null;
      }
    }
    case LOG_TYPE__USER: {
      switch (category) {
        case LOG_CATEGORY__CREATE_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.owner}
                  component={RouterLink}
                  to={`/users/${ownerId}`}
                >
                  {`«${ownerFullName}»`}
                </Link>
              </Box>
              dodał użytkownika
              <Box
                component="span"
                ml={0.5}
              >
                <Link
                  className={styles.user}
                  component={RouterLink}
                  to={`/users/${entity.id}`}
                >
                  {`«${entity.name}»`}
                </Link>
              </Box>
              .
            </>
          );
        case LOG_CATEGORY__REMOVE_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                mx={0.5}
              >
                <Link
                  className={styles.owner}
                  component={RouterLink}
                  to={`/users/${ownerId}`}
                >
                  {`«${ownerFullName}»`}
                </Link>
              </Box>
              usunął użytkownika
              <Box
                component="span"
                ml={0.5}
              >
                <Link
                  className={styles.user}
                  component={RouterLink}
                  to={`/users/${entity.id}`}
                >
                  {`«${entity.name}»`}
                </Link>
              </Box>
              .
            </>
          );
        default:
          return null;
      }
    }
    default:
      return null;
  }
}

export default Text;
