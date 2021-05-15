import {
  FormState,
  FormStateValidationResult,
} from './interfaces';

export const initialFormState = () : FormState => {
  const formState: FormState = {
    name: '',
    symbol: '',
    description: '',
    operatorId: '',
  };
  return formState;
};

export const validateFormState = (formState: FormState) : FormStateValidationResult => {
  const formStateValidationResult: FormStateValidationResult = {
    isValid: true,
    details: {
      name: null,
      symbol: null,
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

  return formStateValidationResult;
};
