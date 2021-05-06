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
    // Szczegóły.
    details: {
      // Komponent zainstalowany na serwerze.
      serverComponent: {
        // Identyfikator produktu.
        productId: string,
        // Nazwa produktu.
        productName: string,
        // Identyfikator komponentu.
        componentId: string,
        // Nazwa komponentu.
        componentName: string,
        // Identyfikator wersji komponentu.
        componentVersionId: string,
        // Numer wersji komponentu.
        componentVersionNumber: string,
      },
      // Oprogramowanie zainstalowane na serwerze.
      serverSoftwareApplication: {
        // Identyfikator oprogramowania.
        softwareApplicationId: string,
        // Nazwa oprogramowania.
        softwareApplicationName: string,
      },
    },
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
    // Szczegóły.
    details: {
      // Komponent zainstalowany na serwerze.
      serverComponent: {
        // Identyfikator produktu.
        productId: string,
        // Nazwa produktu.
        productName: string,
        // Identyfikator komponentu.
        componentId: string,
        // Nazwa komponentu.
        componentName: string,
        // Identyfikator wersji komponentu.
        componentVersionId: string,
        // Numer wersji komponentu.
        componentVersionNumber: string,
      },
      // Oprogramowanie zainstalowane na serwerze.
      serverSoftwareApplication: {
        // Identyfikator oprogramowania.
        softwareApplicationId: string,
        // Nazwa oprogramowania.
        softwareApplicationName: string,
      },
    },
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
