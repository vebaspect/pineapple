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
  // Identyfikator encji.
  entityId: string,
  // Nazwa encji.
  entityName: string,
  // Identyfikator encji nadrzędnej.
  parentEntityId: string,
  // Nazwa encji nadrzędnej.
  parentEntityName: string,
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
  // Identyfikator encji.
  entityId: string,
  // Nazwa encji.
  entityName: string,
  // Identyfikator encji nadrzędnej.
  parentEntityId: string,
  // Nazwa encji nadrzędnej.
  parentEntityName: string,
}

export interface IconProps {
  // Typ.
  type: string,
  // Kategoria.
  category: string,
}
