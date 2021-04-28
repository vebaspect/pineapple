export const formatNumber = (major: number, minor: number, patch: number, suffix: string) : string => {
  return suffix
    ? `${major}.${minor}.${patch}-${suffix}`
    : `${major}.${minor}.${patch}`
};

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
