import React, { useState } from 'react';
import { Link as RouterLink } from 'react-router-dom';

import {
  createStyles,
  makeStyles,
} from '@material-ui/core/styles';

import Box from '@material-ui/core/Box';
import CircularProgress from '@material-ui/core/CircularProgress';
import Collapse from '@material-ui/core/Collapse';
import ExpandLess from '@material-ui/icons/ExpandLess';
import ExpandMore from '@material-ui/icons/ExpandMore';
import Link from '@material-ui/core/Link';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import Tooltip from '@material-ui/core/Tooltip';

import PowerIcon from '@material-ui/icons/Power';
import WarningIcon from '@material-ui/icons/Warning';

import {
  ImplementationsProps,
} from './interfaces';

const useStyles = makeStyles(() =>
  createStyles({
    outdatedEnvironmentNodeWrapper: {
      alignItems: 'center',
      display: 'flex',
    },
    outdatedEnvironmentName: {
      paddingRight: '5px',
    },
    outdatedEnvironmentIcon: {
      color: '#f50057',
      height: '0.7em',
      width: '0.7em',
    },
  }),
);

const Implementations: React.FC<ImplementationsProps> = ({ isDataFetched, data }: ImplementationsProps) => {
  const styles = useStyles();

  // Flaga określająca, czy gałąź "Wdrożenia" jest rozwinięta.
  const [isExpanded, setIsExpanded] = useState(true);

  const onExpandLessButtonClick = () => {
    setIsExpanded(false);
  }

  const onExpandMoreButtonClick = () => {
    setIsExpanded(true);
  }

  if (!isDataFetched) {
    return (
      <ListItem>
        <ListItemIcon>
          <PowerIcon color="primary" />
        </ListItemIcon>
        <ListItemText>
          Wdrożenia
        </ListItemText>
        <CircularProgress size={20} />
      </ListItem>
    );
  }

  return (
    <>
      <ListItem button>
        <ListItemIcon>
          <PowerIcon color="primary" />
        </ListItemIcon>
        <ListItemText>
          <Link
            component={RouterLink}
            to="/implementations"
          >
            Wdrożenia ({data.implementations?.filter((implementation) => !implementation.isDeleted).length})
          </Link>
        </ListItemText>
        {
          data.implementations?.length > 0
            ? (isExpanded ? <ExpandLess onClick={onExpandLessButtonClick} /> : <ExpandMore onClick={onExpandMoreButtonClick} />)
            : null 
        }
      </ListItem>
      <Collapse
        in={isExpanded}
        style={{ paddingLeft: '56px' }}
      >
        <List component="div">
          {
            data.implementations?.length > 0
              ? data.implementations.filter((implementation) => !implementation.isDeleted).map((implementation) => {
                return (
                  <React.Fragment key={implementation.id}>
                    <ListItem
                      button
                      style={{ paddingBottom: '4px', paddingTop: '4px' }}
                    >
                      <ListItemText>
                        <Tooltip title={implementation.description} placement="right">
                          <Link
                            component={RouterLink}
                            to={`/implementations/${implementation.id}`}
                            style={{ fontSize: '0.9rem' }}
                          >
                            {implementation.name}
                          </Link>
                        </Tooltip>
                      </ListItemText>
                    </ListItem>
                    {
                      implementation.environments?.length > 0
                        ? implementation.environments.filter((environment) => !environment.isDeleted).map((environment) => {
                          return (
                            <React.Fragment key={environment.id}>
                              <ListItem
                                button
                                style={{ paddingBottom: '2px', paddingLeft: '32px', paddingTop: '2px' }}
                              >
                                <ListItemText style={{ marginBottom: '0', marginTop: '0' }}>
                                  <Tooltip title={environment.description} placement="right">
                                    <Link
                                      component={RouterLink}
                                      to={`/implementations/${implementation.id}/environments/${environment.id}`}
                                      style={{ fontSize: '0.75rem' }}
                                    >
                                      {
                                        environment.isUpdateAvailable
                                          ? (
                                            <Box className={styles.outdatedEnvironmentNodeWrapper}>
                                              <strong className={styles.outdatedEnvironmentName}>
                                                {environment.name}
                                              </strong>
                                              <Tooltip title="Dostępne są nowsze wersje zainstalowanych komponentów!">
                                                <WarningIcon className={styles.outdatedEnvironmentIcon} />
                                              </Tooltip>
                                            </Box>
                                          )
                                          : (
                                            <Box>
                                              {environment.name}
                                            </Box>
                                          )
                                      }
                                    </Link>
                                  </Tooltip>
                                </ListItemText>
                              </ListItem>
                            </React.Fragment>
                          );
                        })
                        : null
                    }
                  </React.Fragment>
                )
              })
              : null
          }
        </List>
      </Collapse>
    </>
  )
}

export default Implementations;
