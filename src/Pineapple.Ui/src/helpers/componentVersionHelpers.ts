export const translateKind = (kind: string) : string => {
  switch (kind) {
    case 'PreRelease':
      return 'Wydanie przedpremierowe';
    case 'Release':
      return 'Wydanie';
    case 'Patch':
      return 'Łatka';
    default:
      return '';
  }
};
