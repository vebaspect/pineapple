import React, { useState } from 'react';

import CircularProgress from '@material-ui/core/CircularProgress';
import Collapse from '@material-ui/core/Collapse';
import ExpandLess from '@material-ui/icons/ExpandLess';
import ExpandMore from '@material-ui/icons/ExpandMore';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';

interface Props {
  // Flaga określająca, czy liczba typów komponentów została pobrana z API.
  isComponentTypesCountFetched: boolean,
  // Liczba typów komponentów.
  componentTypesCount: number;
  // Flaga określająca, czy liczba systemów operacyjnych została pobrana z API.
  isOperatingSystemsCountFetched: boolean,
  // Liczba systemów operacyjnych.
  operatingSystemsCount: number;
  // Flaga określająca, czy liczba oprogramowania została pobrana z API.
  isSoftwareApplicationsCountFetched: boolean,
  // Liczba oprogramowania.
  softwareApplicationsCount: number;
};

const Configuration = ({ isComponentTypesCountFetched, componentTypesCount, isOperatingSystemsCountFetched, operatingSystemsCount, isSoftwareApplicationsCountFetched, softwareApplicationsCount }: Props) => {
  // Flaga określająca, czy konfiguracja jest rozwinięta.
  const [isExpanded, setIsExpanded] = useState(false);

  const onHeaderClick = () => {
    setIsExpanded(!isExpanded);
  };

  if (!isComponentTypesCountFetched && !isOperatingSystemsCountFetched && !isSoftwareApplicationsCountFetched) {
    return (
      <ListItem>
        <ListItemText>
          Konfiguracja
        </ListItemText>
        <CircularProgress size={20} />
      </ListItem>
    );
  }

  return (
    <>
      <ListItem button onClick={onHeaderClick}>
        <ListItemText>
          Konfiguracja
        </ListItemText>
        {isExpanded ? <ExpandLess /> : <ExpandMore />}
      </ListItem>
      <Collapse in={isExpanded}>
        <List component="div">
          <ListItem button>
            <ListItemText>
              Typy komponentów ({componentTypesCount})
            </ListItemText>
          </ListItem>
          <ListItem button>
            <ListItemText>
              Systemy operacyjne ({operatingSystemsCount})
            </ListItemText>
          </ListItem>
          <ListItem button>
            <ListItemText>
              Oprogramowanie ({softwareApplicationsCount})
            </ListItemText>
          </ListItem>
        </List>
      </Collapse>
    </>
  )
}

export default Configuration;
