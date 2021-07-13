import {
  KIND__PATCH,
  KIND__PRE_RELEASE,
  KIND__RELEASE,
} from './componentVersionConstants';

// Funkcja formatująca numer wersji komponentu.
export const formatNumber = (major: number, minor: number, patch: number, suffix: string) : string => {
  return suffix
    ? `${major}.${minor}.${patch}-${suffix}`
    : `${major}.${minor}.${patch}`
};

// Funkcja tłumacząca rodzaj wersji komponentu.
export const translateKind = (kind: string) : string => {
  switch (kind) {
    case KIND__PATCH:
      return 'Poprawka';
    case KIND__PRE_RELEASE:
      return 'Wersja przedpremierowa';
    case KIND__RELEASE:
      return 'Wersja';
    default:
      return '';
  }
};
