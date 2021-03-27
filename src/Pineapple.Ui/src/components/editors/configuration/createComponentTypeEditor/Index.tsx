import React, { useState } from 'react';
import { useHistory } from 'react-router-dom';

import Box from '@material-ui/core/Box';
import Button from '@material-ui/core/Button';
import Paper from '@material-ui/core/Paper';
import TextField from '@material-ui/core/TextField';

import SaveIcon from '@material-ui/icons/Save';

const initialEditorState = {
  name: '',
  symbol: '',
  description: '',
};

const CreateComponentTypeEditor = () => {
  const [editorState, setEditorState] = useState(initialEditorState);

  const history = useHistory();

  const onNameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setEditorState({
      ...editorState,
      name: event.target.value,
    });
  };

  const onSymbolChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setEditorState({
      ...editorState,
      symbol: event.target.value,
    });
  };

  const onDescriptionChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setEditorState({
      ...editorState,
      description: event.target.value,
    });
  };

  const onSave = async () => {
    await fetch(
      `${window['env'].API_URL}/configuration/component-types`,
      {
        body: JSON.stringify(editorState),
        headers: {
          'Content-Type': 'application/json',
        },
        method: 'POST',
      },
    )
    .then(() => {
      history.push('/component-types');
    });
  };

  return (
    <>
      <Box
        fontSize="h6.fontSize"
        m={2}
        textAlign="center"
      >
        Dodaj typ komponentu
      </Box>
      <Box>
        <Paper>
          <Box
            px={4}
            pb={2}
            pt={4}
          >
            <TextField
              fullWidth
              label="Nazwa"
              helperText="Maksymalnie 200 znaków."
              value={editorState.name}
              onChange={onNameChange}
            />
          </Box>
          <Box
            px={4}
            pb={2}
          >
            <TextField
              fullWidth
              label="Symbol"
              helperText="Maksymalnie 200 znaków."
              value={editorState.symbol}
              onChange={onSymbolChange}
            />
          </Box>
          <Box
            px={4}
            pb={2}
          >
            <TextField
              fullWidth
              label="Opis"
              helperText="Maksymalnie 4000 znaków."
              value={editorState.description}
              onChange={onDescriptionChange}
            />
          </Box>
          <Box
            pb={3}
            pr={4}
            pt={1}
            textAlign="right"
          >
            <Button
              color="primary"
              size="small"
              startIcon={<SaveIcon />}
              variant="contained"
              onClick={onSave}
            >
              Zapisz
            </Button>
          </Box>
        </Paper>
      </Box>
    </>
  )
}

export default CreateComponentTypeEditor;
