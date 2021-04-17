export interface LogProps {
  // Data modyfikacji.
  modificationDate: Date,
  // Typ.
  type: string,
  // Kategoria.
  category: string,
  // Imię i nazwisko właściciela.
  ownerFullName: string,
  // Nazwa encji.
  entityName: string,
  // Nazwa encji nadrzędnej.
  parentEntityName: string,
}

export interface TextProps {
  // Typ.
  type: string,
  // Kategoria.
  category: string,
  // Imię i nazwisko właściciela.
  ownerFullName: string,
  // Nazwa encji.
  entityName: string,
  // Nazwa encji nadrzędnej.
  parentEntityName: string,
}

export interface IconProps {
  // Typ.
  type: string,
  // Kategoria.
  category: string,
}
