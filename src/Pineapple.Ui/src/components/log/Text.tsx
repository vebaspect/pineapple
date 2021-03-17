import React from 'react';

import Box from '@material-ui/core/Box';

import {
  LOG_TYPE__COMPONENT,
  LOG_TYPE__COMPONENT_VERSION,
  LOG_TYPE__ENVIRONMENT,
  LOG_TYPE__IMPLEMENTATION,
  LOG_TYPE__PRODUCT,
  LOG_TYPE__SERVER,
  LOG_TYPE__USER,
  LOG_CATEGORY__ADD_ENTITY,
  LOG_CATEGORY__REMOVE_ENTITY,
} from './constants';

interface Props {
  // Typ.
  type: string,
  // Kategoria.
  category: string,
  // Imię i nazwisko właściciela.
  ownerFullName: string,
  // Nazwa encji.
  entityName: string,
  // Nazwa encji nadrzędnej.
  parentEntityName: string,
};

const Text = ({ type, category, ownerFullName, entityName, parentEntityName }: Props) => {
  switch (type) {
    case LOG_TYPE__COMPONENT: {
      switch (category) {
        case LOG_CATEGORY__ADD_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                color="text.secondary"
                mx={0.5}
              >
                {`@${ownerFullName}`}
              </Box>
              dodał komponent
              <Box
                component="span"
                color="info.main"
                mx={0.5}
              >
                {entityName}
              </Box>
              do produktu
              <Box
                component="span"
                color="info.main"
                ml={0.5}
              >
                {parentEntityName}
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
                color="text.secondary"
                mx={0.5}
              >
                {`@${ownerFullName}`}
              </Box>
              usunął komponent
              <Box
                component="span"
                color="info.main"
                mx={0.5}
              >
                {entityName}
              </Box>
              z produktu
              <Box
                component="span"
                color="info.main"
                ml={0.5}
              >
                {parentEntityName}
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
        case LOG_CATEGORY__ADD_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                color="text.secondary"
                mx={0.5}
              >
                {`@${ownerFullName}`}
              </Box>
              wydał wersję
              <Box
                component="span"
                color="info.main"
                mx={0.5}
              >
                {entityName}
              </Box>
              komponentu
              <Box
                component="span"
                color="info.main"
                ml={0.5}
              >
                {parentEntityName}
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
        case LOG_CATEGORY__ADD_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                color="text.secondary"
                mx={0.5}
              >
                {`@${ownerFullName}`}
              </Box>
              dodał środowisko
              <Box
                component="span"
                color="info.main"
                mx={0.5}
              >
                {entityName}
              </Box>
              do wdrożenia
              <Box
                component="span"
                color="info.main"
                ml={0.5}
              >
                {parentEntityName}
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
        case LOG_CATEGORY__ADD_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                color="text.secondary"
                mx={0.5}
              >
                {`@${ownerFullName}`}
              </Box>
              dodał wdrożenie
              <Box
                component="span"
                color="info.main"
                ml={0.5}
              >
                {entityName}
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
                color="text.secondary"
                mx={0.5}
              >
                {`@${ownerFullName}`}
              </Box>
              usunął wdrożenie
              <Box
                component="span"
                color="info.main"
                ml={0.5}
              >
                {entityName}
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
        case LOG_CATEGORY__ADD_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                color="text.secondary"
                mx={0.5}
              >
                {`@${ownerFullName}`}
              </Box>
              dodał produkt
              <Box
                component="span"
                color="info.main"
                ml={0.5}
              >
                {entityName}
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
                color="text.secondary"
                mx={0.5}
              >
                {`@${ownerFullName}`}
              </Box>
              usunął produkt
              <Box
                component="span"
                color="info.main"
                ml={0.5}
              >
                {entityName}
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
        case LOG_CATEGORY__ADD_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                color="text.secondary"
                mx={0.5}
              >
                {`@${ownerFullName}`}
              </Box>
              dodał serwer
              <Box
                component="span"
                color="info.main"
                mx={0.5}
              >
                {entityName}
              </Box>
              do wdrożenia
              <Box
                component="span"
                color="info.main"
                ml={0.5}
              >
                {parentEntityName}
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
        case LOG_CATEGORY__ADD_ENTITY:
          return (
            <>
              Użytkownik
              <Box
                component="span"
                color="text.secondary"
                mx={0.5}
              >
                {`@${ownerFullName}`}
              </Box>
              dodał użytkownika
              <Box
                component="span"
                color="info.main"
                ml={0.5}
              >
                {entityName}
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
                color="text.secondary"
                mx={0.5}
              >
                {`@${ownerFullName}`}
              </Box>
              usunął użytkownika
              <Box
                component="span"
                color="info.main"
                ml={0.5}
              >
                {entityName}
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
