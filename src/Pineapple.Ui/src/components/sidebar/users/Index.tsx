import React, { useState } from 'react';
import { Link as RouterLink } from 'react-router-dom';

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

interface Props {
  // Flaga określająca, czy liczba programistów została pobrana z API.
  isDevelopersCountFetched: boolean,
  // Liczba programistów.
  developersCount: number;
  // Flaga określająca, czy liczba wdrożeniowców została pobrana z API.
  isOperatorsCountFetched: boolean,
  // Liczba wdrożeniowców.
  operatorsCount: number;
  // Flaga określająca, czy liczba menedżerów pobrana z API.
  isManagersCountFetched: boolean,
  // Liczba menedżerów.
  managersCount: number;
  // Flaga określająca, czy liczba administratorów została pobrana z API.
  isAdministratorsCountFetched: boolean,
  // Liczba administratorów.
  administratorsCount: number;
};

const Users = ({ isDevelopersCountFetched, developersCount, isOperatorsCountFetched, operatorsCount, isManagersCountFetched, managersCount, isAdministratorsCountFetched, administratorsCount }: Props) => {
  // Flaga określająca, czy konfiguracja jest rozwinięta.
  const [isExpanded, setIsExpanded] = useState(false);

  const onHeaderClick = () => {
    setIsExpanded(!isExpanded);
  };

  if (!isDevelopersCountFetched && !isOperatorsCountFetched && !isManagersCountFetched && !isAdministratorsCountFetched) {
    return (
      <ListItem>
        <ListItemIcon>
          <SupervisorAccountIcon />
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
      <ListItem button onClick={onHeaderClick}>
        <ListItemIcon>
          <SupervisorAccountIcon />
        </ListItemIcon>
        <ListItemText>
          <Link
            component={RouterLink}
            to="/users"
          >
            Użytkownicy
          </Link>
        </ListItemText>
        {isExpanded ? <ExpandLess /> : <ExpandMore />}
      </ListItem>
      <Collapse
        in={isExpanded}
        style={{ paddingLeft: '16px' }}
      >
        <List component="div">
          <ListItem button>
            <ListItemText>
              <Link
                component={RouterLink}
                to="/developers"
                style={{ fontSize: '0.9rem' }}
              >
                Programiści ({developersCount})
              </Link>
            </ListItemText>
          </ListItem>
          <ListItem button>
            <ListItemText>
              <Link
                component={RouterLink}
                to="/operators"
                style={{ fontSize: '0.9rem' }}
              >
                Wdrożeniowcy ({operatorsCount})
              </Link>
            </ListItemText>
          </ListItem>
          <ListItem button>
            <ListItemText>
              <Link
                component={RouterLink}
                to="/managers"
                style={{ fontSize: '0.9rem' }}
              >
                Menedżerowie ({managersCount})
              </Link>
            </ListItemText>
          </ListItem>
          <ListItem button>
            <ListItemText>
              <Link
                component={RouterLink}
                to="/administrators"
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
