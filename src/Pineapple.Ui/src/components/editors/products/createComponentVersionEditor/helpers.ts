import moment from 'moment-timezone';

import {
  ApiFormat,
  FormState,
  FormStateValidationResult,
} from './interfaces';

export const convertFormStateToApiFormat = (formState: FormState) : ApiFormat => {
  const requestBody: ApiFormat = {
    releaseDate: formState.releaseDate,
    major: parseInt(formState.major),
    minor: parseInt(formState.minor),
    patch: parseInt(formState.patch),
    suffix: formState.suffix,
    description: formState.description,
  };

  return requestBody;
};

export const initialFormState = () : FormState => {
  const formState: FormState = {
    releaseDate: moment().tz('Poland').format(),
    major: '',
    minor: '',
    patch: '',
    suffix: '',
    description: '',
  };
  return formState;
};

export const validateFormState = (formState: FormState) : FormStateValidationResult => {
  const formStateValidationResult: FormStateValidationResult = {
    isValid: true,
    details: {
      releaseDate: null,
      major: null,
      minor: null,
      patch: null,
    },
  };

  if (!formState.releaseDate) {
    formStateValidationResult.isValid = false;
    formStateValidationResult.details.releaseDate = 'Pole wymagane.';
  }
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
