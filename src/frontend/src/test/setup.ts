import "@testing-library/jest-dom";
import { cleanup, configure } from "@testing-library/react";
import "../utilities/i18n";

// override attribute name testIdAttribute
configure({ testIdAttribute: "id" });

afterEach(() => {
  cleanup();
});

beforeEach(() => {
  cleanup();
});
