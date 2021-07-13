import {
  FormState,
  FormStateValidationResult,
} from './interfaces';

export const initialFormState = () : FormState => {
  const formState: FormState = {
    name: '',
    sourceCodeRepositoryUrl: '',
    packagesRepositoryPath: '',
    description: '',
    componentTypeId: '',
  };
  return formState;
};

export const validateFormState = (formState: FormState) : FormStateValidationResult => {
  const formStateValidationResult: FormStateValidationResult = {
    isValid: true,
    details: {
      name: null,
      componentTypeId: null,
    },
  };

  if (!formState.name) {
    formStateValidationResult.isValid = false;
    formStateValidationResult.details.name = 'Pole wymagane.';
  }
  if (!formState.componentTypeId) {
    formStateValidationResult.isValid = false;
    formStateValidationResult.details.componentTypeId = 'Pole wymagane.';
  }

  return formStateValidationResult;
};
