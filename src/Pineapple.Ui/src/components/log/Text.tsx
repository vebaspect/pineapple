import React from 'react';

import Box from '@material-ui/core/Box';

import {
  LOG_TYPE__IMPLEMENTATION,
  LOG_TYPE__PRODUCT,
  LOG_CATEGORY__ADD_ENTITY,
} from './constants';

interface Props {
  // Typ.
  type: string,
  // Kategoria.
  category: string,
  // Imię i nazwisko użytkownika.
  userFullName: string,
  // Nazwa encji.
  entityName: string,
};

const Text = ({ type, category, userFullName, entityName }: Props) => {
  switch (type) {
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
                {`@${userFullName}`}
              </Box>
              dodał nowe wdrożenie:
              <Box
                component="span"
                color="info.main"
                fontStyle="italic"
                ml={0.5}
              >
                {entityName}
              </Box>
              .
            </>
          )
        default:
          return null;
      }
    }
    case LOG_TYPE__PRODUCT:
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
                {`@${userFullName}`}
              </Box>
              dodał nowy produkt:
              <Box
                component="span"
                color="info.main"
                fontStyle="italic"
                ml={0.5}
              >
                {entityName}
              </Box>
              .
            </>
          )
        default:
          return null;
      }
    default:
      return null;
  }
}

export default Text;
