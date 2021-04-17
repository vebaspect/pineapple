export interface LogProps {
  // Data modyfikacji.
  modificationDate: Date,
  // Typ.
  type: string,
  // Kategoria.
  category: string,
  // Identyfikator właściciela.
  ownerId: string,
  // Imię i nazwisko właściciela.
  ownerFullName: string,
  // Encja.
  entity: {
    // Identyfikator.
    id: string,
    // Nazwa.
    name: string,
  },
  // Encje nadrzędne.
  parentEntities: {
    // Identyfikator.
    id: string,
    // Nazwa.
    name: string,
  }[],
}

export interface TextProps {
  // Typ.
  type: string,
  // Kategoria.
  category: string,
  // Identyfikator właściciela.
  ownerId: string,
  // Imię i nazwisko właściciela.
  ownerFullName: string,
  // Encja.
  entity: {
    // Identyfikator.
    id: string,
    // Nazwa.
    name: string,
  },
  // Encje nadrzędne.
  parentEntities: {
    // Identyfikator.
    id: string,
    // Nazwa.
    name: string,
  }[],
}

export interface IconProps {
  // Typ.
  type: string,
  // Kategoria.
  category: string,
}
