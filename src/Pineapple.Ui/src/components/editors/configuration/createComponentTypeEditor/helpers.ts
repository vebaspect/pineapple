export const initialFormState = () => {
  return {
    name: '',
    symbol: '',
    description: '',
  };
};

interface FormState {
  // Nazwa.
  name: string,
  // Symbol.
  symbol: string,
  // Opis.
  description: string,
};

interface FormStateValidationResult {
  // Flaga określająca, czy stan formularza jest poprawny.
  isValid: boolean,
  // Stan poszczególnych pól formularza.
  details: {
    // Nazwa.
    name: string,
    // Symbol.
    symbol: string,
  },
};

export const validateFormState = (formState: FormState) => {
  let formStateValidationResult: FormStateValidationResult = {
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
