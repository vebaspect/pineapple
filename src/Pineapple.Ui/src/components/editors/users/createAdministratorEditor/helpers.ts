import {
  FormState,
  FormStateValidationResult,
} from './interfaces';

export const initialFormState = () : FormState => {
  const formState: FormState = {
    fullName: '',
    login: '',
    phone: '',
    email: '',
  };
  return formState;
};

export const validateFormState = (formState: FormState) : FormStateValidationResult => {
  const formStateValidationResult: FormStateValidationResult = {
    isValid: true,
    details: {
      fullName: '',
      login: '',
    },
  };

  if (!formState.fullName) {
    formStateValidationResult.isValid = false;
    formStateValidationResult.details.fullName = 'Pole wymagane.';
  }
  if (!formState.login) {
    formStateValidationResult.isValid = false;
    formStateValidationResult.details.login = 'Pole wymagane.';
  }

  return formStateValidationResult;
};
