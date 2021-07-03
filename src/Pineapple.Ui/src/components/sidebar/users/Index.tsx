import React, { useState } from 'react';
import { Link as RouterLink, useLocation } from 'react-router-dom';

import CircularProgress from '@material-ui/core/CircularProgress';
import Collapse from '@material-ui/core/Collapse';
import ExpandLess from '@material-ui/icons/ExpandLess';
import ExpandMore from '@material-ui/icons/ExpandMore';
import Link from '@material-ui/core/Link';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';

import SupervisorAccountIcon from '@material-ui/icons/SupervisorAccount';

import {
  UsersProps,
} from './interfaces';

const Users: React.FC<UsersProps> = ({ isDevelopersCountFetched, developersCount, isOperatorsCountFetched, operatorsCount, isManagersCountFetched, managersCount, isAdministratorsCountFetched, administratorsCount }: UsersProps) => {
  const location = useLocation();

  // Flaga określająca, czy gałąź "Użytkownicy" jest rozwinięta.
  const [isExpanded, setIsExpanded] = useState(false);

  const onExpandLessButtonClick = () => {
    setIsExpanded(false);
  }

  const onExpandMoreButtonClick = () => {
    setIsExpanded(true);
  }

  if (!isDevelopersCountFetched && !isOperatorsCountFetched && !isManagersCountFetched && !isAdministratorsCountFetched) {
    return (
      <ListItem>
        <ListItemIcon>
          <SupervisorAccountIcon color="primary" />
        </ListItemIcon>
        <ListItemText>
          Użytkownicy
        </ListItemText>
        <CircularProgress size={20} />
      </ListItem>
    );
  }

  return (
    <>
      <ListItem
        button
        style={
          location.pathname === '/users'
            ? { backgroundColor: '#f2f4ff' }
            : null
        }
      >
        <ListItemIcon>
          <SupervisorAccountIcon color="primary" />
        </ListItemIcon>
        <ListItemText>
          <Link
            component={RouterLink}
            to="/users"
          >
            Użytkownicy
          </Link>
        </ListItemText>
        {isExpanded ? <ExpandLess onClick={onExpandLessButtonClick} /> : <ExpandMore onClick={onExpandMoreButtonClick} />}
      </ListItem>
      <Collapse in={isExpanded}>
        <List component="div">
          <ListItem
            button
            style={
              location.pathname === '/users/developers'
                ? { backgroundColor: '#f2f4ff', paddingLeft: '72px' }
                : { paddingLeft: '72px' }
            }
          >
            <ListItemText>
              <Link
                component={RouterLink}
                to="/users/developers"
                style={{ fontSize: '0.9rem' }}
              >
                Programiści ({developersCount})
              </Link>
            </ListItemText>
          </ListItem>
          <ListItem
            button
            style={
              location.pathname === '/users/operators'
                ? { backgroundColor: '#f2f4ff', paddingLeft: '72px' }
                : { paddingLeft: '72px' }
            }
          >
            <ListItemText>
              <Link
                component={RouterLink}
                to="/users/operators"
                style={{ fontSize: '0.9rem' }}
              >
                Wdrożeniowcy ({operatorsCount})
              </Link>
            </ListItemText>
          </ListItem>
          <ListItem
            button
            style={
              location.pathname === '/users/managers'
                ? { backgroundColor: '#f2f4ff', paddingLeft: '72px' }
                : { paddingLeft: '72px' }
            }
          >
            <ListItemText>
              <Link
                component={RouterLink}
                to="/users/managers"
                style={{ fontSize: '0.9rem' }}
              >
                Menedżerowie ({managersCount})
              </Link>
            </ListItemText>
          </ListItem>
          <ListItem
            button
            style={
              location.pathname === '/users/administrators'
                ? { backgroundColor: '#f2f4ff', paddingLeft: '72px' }
                : { paddingLeft: '72px' }
            }
          >
            <ListItemText>
              <Link
                component={RouterLink}
                to="/users/administrators"
                style={{ fontSize: '0.9rem' }}
              >
                Administratorzy ({administratorsCount})
              </Link>
            </ListItemText>
          </ListItem>
        </List>
      </Collapse>
    </>
  )
}

export default Users;
