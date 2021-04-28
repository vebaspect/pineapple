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
      productId: null,
      componentId: null,
      componentVersionId: null,
    },
  };

  if (!formState.productId) {
    formStateValidationResult.isValid = false;
    formStateValidationResult.details.productId = 'Pole wymagane.';
  }
  if (!formState.componentId) {
    formStateValidationResult.isValid = false;
    formStateValidationResult.details.componentId = 'Pole wymagane.';
  }
  if (!formState.componentVersionId) {
    formStateValidationResult.isValid = false;
    formStateValidationResult.details.componentVersionId = 'Pole wymagane.';
  }

  return formStateValidationResult;
};
