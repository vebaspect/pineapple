import React, { useState } from 'react';
import { Link } from "react-router-dom";

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
          <Link
            to="/configuration"
            style={{ textDecoration: 'none'}}
          >
            Konfiguracja
          </Link>
        </ListItemText>
        {isExpanded ? <ExpandLess /> : <ExpandMore />}
      </ListItem>
      <Collapse in={isExpanded}>
        <List component="div">
          <ListItem button>
            <ListItemText>
              <Link
                to="/component-types"
                style={{ textDecoration: 'none'}}
              >
                Typy komponentów ({componentTypesCount})
              </Link>
            </ListItemText>
          </ListItem>
          <ListItem button>
            <ListItemText>
              <Link
                to="/operating-systems"
                style={{ textDecoration: 'none'}}
              >
                Systemy operacyjne ({operatingSystemsCount})
              </Link>
            </ListItemText>
          </ListItem>
          <ListItem button>
            <ListItemText>
              <Link
                to="/software-applications"
                style={{ textDecoration: 'none'}}
              >
                Oprogramowanie ({softwareApplicationsCount})
              </Link>
            </ListItemText>
          </ListItem>
        </List>
      </Collapse>
    </>
  )
}

export default Configuration;
