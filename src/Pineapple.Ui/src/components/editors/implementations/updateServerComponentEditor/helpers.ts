import {
  FormState,
  FormStateValidationResult,
} from './interfaces';

export const initialFormState = () : FormState => {
  const formState: FormState = {
    productId: '',
    componentId: '',
    componentVersionId: '',
  };
  return formState;
};

export const validateFormState = (formState: FormState) : FormStateValidationResult => {
  const formStateValidationResult: FormStateValidationResult = {
    isValid: true,
    details: {
      componentVersionId: null,
    },
  };

  if (!formState.componentVersionId) {
    formStateValidationResult.isValid = false;
    formStateValidationResult.details.componentVersionId = 'Pole wymagane.';
  }

  return formStateValidationResult;
};
