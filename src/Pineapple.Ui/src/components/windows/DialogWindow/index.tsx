import React from 'react';

import Button from '@material-ui/core/Button';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';

import {
  DialogWindowProps,
} from '../interfaces';

const DialogWindow: React.FC<DialogWindowProps> = ({ isOpen, title, onConfirm, onCancel, children }: DialogWindowProps) => {
  return (
    <Dialog open={isOpen}>
      <DialogTitle>
        {title}
      </DialogTitle>
      <DialogContent>
        <DialogContentText>
          {children}
        </DialogContentText>
      </DialogContent>
      <DialogActions>
        <Button
          size="small"
          onClick={onCancel}
        >
          Anuluj
        </Button>
        <Button
          autoFocus
          color="primary"
          size="small"
          onClick={onConfirm}
        >
          Potwierdź
        </Button>
      </DialogActions>
    </Dialog>
  );
}

export default DialogWindow;
