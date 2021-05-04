import {
  FormState,
  FormStateValidationResult,
} from './interfaces';

export const initialFormState = () : FormState => {
  const formState: FormState = {
    softwareApplicationId: '',
  };
  return formState;
};

export const validateFormState = (formState: FormState) : FormStateValidationResult => {
  const formStateValidationResult: FormStateValidationResult = {
    isValid: true,
    details: {
      softwareApplicationId: null,
    },
  };

  if (!formState.softwareApplicationId) {
    formStateValidationResult.isValid = false;
    formStateValidationResult.details.softwareApplicationId = 'Pole wymagane.';
  }

  return formStateValidationResult;
};
