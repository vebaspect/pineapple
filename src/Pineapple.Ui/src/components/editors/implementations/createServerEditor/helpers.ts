import {
  FormState,
  FormStateValidationResult,
} from './interfaces';

export const initialFormState = () : FormState => {
  const formState: FormState = {
    name: '',
    symbol: '',
    ipAddress: '',
    description: '',
    operatingSystemId: '',
  };
  return formState;
};

export const validateFormState = (formState: FormState) : FormStateValidationResult => {
  const formStateValidationResult: FormStateValidationResult = {
    isValid: true,
    details: {
      name: null,
      symbol: null,
      ipAddress: null,
      operatingSystemId: null,
    },
  };

  if (!formState.name) {
    formStateValidationResult.isValid = false;
    formStateValidationResult.details.name = 'Pole wymagane.';
  }
  if (!formState.symbol) {
    formStateValidationResult.isValid = false;
    formStateValidationResult.details.symbol = 'Pole wymagane.';
  }
  if (!formState.ipAddress) {
    formStateValidationResult.isValid = false;
    formStateValidationResult.details.ipAddress = 'Pole wymagane.';
  }
  if (!formState.operatingSystemId) {
    formStateValidationResult.isValid = false;
    formStateValidationResult.details.operatingSystemId = 'Pole wymagane.';
  }

  return formStateValidationResult;
};
