import React from 'react';
import { useParams } from 'react-router-dom';

const Implementation = () => {
  const { implementationId } = useParams();

  return (
    <>
      Wdrożenie {implementationId}
    </>
  );
}

export default Implementation;
