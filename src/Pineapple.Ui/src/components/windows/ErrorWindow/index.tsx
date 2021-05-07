import React from 'react';

import Button from '@material-ui/core/Button';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';

import {
  ErrorWindowProps,
} from '../interfaces';

const ErrorWindow: React.FC<ErrorWindowProps> = ({ isOpen, onClose, children }: ErrorWindowProps) => {
  return (
    <Dialog open={isOpen}>
      <DialogTitle>
        Wystąpił błąd
      </DialogTitle>
      <DialogContent>
        <DialogContentText>
          {children}
        </DialogContentText>
      </DialogContent>
      <DialogActions>
        <Button
          autoFocus
          color="primary"
          size="small"
          onClick={onClose}
        >
          Zamknij
        </Button>
      </DialogActions>
    </Dialog>
  );
}

export default ErrorWindow;
