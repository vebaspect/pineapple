import {
  LOG_TYPE__IMPLEMENTATION,
  LOG_TYPE__PRODUCT,
  LOG_CATEGORY__ADD_ENTITY,
} from './constants';

interface Log {
  // Identyfikator.
  id: string,
  // Typ.
  type: string,
  // Kategoria.
  category: string,
  // Imię i nazwisko użytkownika.
  userFullName: string,
  // Opis.
  description: string,
};

export const format = (log: Log) => {
  switch (log.type) {
    case LOG_TYPE__IMPLEMENTATION:
      return formatImplementationLog(log);
    case LOG_TYPE__PRODUCT:
      return formatProductLog(log);
    default:
      return '';
  }
};

const formatImplementationLog = (log: Log) => {
  switch (log.category) {
    case LOG_CATEGORY__ADD_ENTITY:
      return `Użytkownik ${log.userFullName} dodał nowe wdrożenie`;
    default:
      return '';
  }
};

const formatProductLog = (log: Log) => {
  switch (log.category) {
    case LOG_CATEGORY__ADD_ENTITY:
      return `Użytkownik ${log.userFullName} dodał nowy produkt`;
    default:
      return '';
  }
};
