import React from 'react';

import Container from '@material-ui/core/Container';
import CssBaseline from '@material-ui/core/CssBaseline';
import Grid from '@material-ui/core/Grid';
import { createMuiTheme, ThemeProvider } from '@material-ui/core/styles';

const Root = () => {
  const theme = createMuiTheme();

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Container>
        <Grid container>
          <Grid item xs={12}>
            {'Hello world!'}
          </Grid>
        </Grid>
        <Grid container>
          <Grid item xs={3}>
            {'Hello world!'}
          </Grid>
          <Grid item xs={9}>
            {'Hello world!'}
          </Grid>
        </Grid>
      </Container>
    </ThemeProvider>
  )
}

export default Root;
