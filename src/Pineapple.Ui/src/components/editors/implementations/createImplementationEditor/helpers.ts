import {
  FormState,
  FormStateValidationResult,
} from './interfaces';

export const initialFormState = () : FormState => {
  const formState: FormState = {
    name: '',
    description: '',
    managerId: '',
  };
  return formState;
};

export const validateFormState = (formState: FormState) : FormStateValidationResult => {
  const formStateValidationResult: FormStateValidationResult = {
    isValid: true,
    details: {
      name: null,
      managerId: null,
    },
  };

  if (!formState.name) {
    formStateValidationResult.isValid = false;
    formStateValidationResult.details.name = 'Pole wymagane.';
  }
  if (!formState.managerId) {
    formStateValidationResult.isValid = false;
    formStateValidationResult.details.managerId = 'Pole wymagane.';
  }

  return formStateValidationResult;
};
