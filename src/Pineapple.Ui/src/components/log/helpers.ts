import {
  LOG_TYPE__IMPLEMENTATION,
  LOG_TYPE__PRODUCT,
} from './constants';

export const logFormatter = (log: { id?: string; type: any; description?: string; }) => {
  switch (log.type) {
    case LOG_TYPE__IMPLEMENTATION:
      return 'Wdrożenie';
    case LOG_TYPE__PRODUCT:
      return 'Produkt';
    default:
      break;
  }
};
