import {
  ApiFormat,
  FormState,
  FormStateValidationResult,
} from './interfaces';

export const convertFormStateToApiFormat = (formState: FormState) : ApiFormat => {
  const requestBody: ApiFormat = {
    major: parseInt(formState.major),
    minor: parseInt(formState.minor),
    patch: parseInt(formState.patch),
    preRelease: formState.preRelease,
    description: formState.description,
  };

  return requestBody;
};

export const initialFormState = () : FormState => {
  const formState: FormState = {
    major: '',
    minor: '',
    patch: '',
    preRelease: '',
    description: '',
  };
  return formState;
};

export const validateFormState = (formState: FormState) : FormStateValidationResult => {
  const formStateValidationResult: FormStateValidationResult = {
    isValid: true,
    details: {
      major: null,
      minor: null,
      patch: null,
    },
  };

  if (!formState.major) {
    formStateValidationResult.isValid = false;
    formStateValidationResult.details.major = 'Pole wymagane.';
  }
  if (!formState.minor) {
    formStateValidationResult.isValid = false;
    formStateValidationResult.details.minor = 'Pole wymagane.';
  }
  if (!formState.patch) {
    formStateValidationResult.isValid = false;
    formStateValidationResult.details.patch = 'Pole wymagane.';
  }

  return formStateValidationResult;
};
