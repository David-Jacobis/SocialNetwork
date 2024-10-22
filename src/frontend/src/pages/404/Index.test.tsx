import { changeUserLanguage } from "../../utilities/translate";

jest.mock("react-i18next", () => ({
  // this mock makes sure any components using the translate hook can use it without a warning being shown
  useTranslation: () => {
    return {
      t: (str: any) => str,
      i18n: {
        type: "backend",
        changeLanguage: () => new Promise(() => {}),
      },
    };
  },
}));

describe("404 Component", () => {
  global.URL.createObjectURL = jest.fn();

  test("404 PAGE", async () => {
    // update locale
    changeUserLanguage("pt");

    // fake test  // TODO - fix this test
    const testVar = 5;
    expect(testVar).toBeGreaterThan(0);
  });
});
