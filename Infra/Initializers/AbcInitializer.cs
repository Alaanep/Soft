namespace ABC.Infra.Initializers;

public static class AbcInitializer {
    public static void Init(ABCDb abcDb) {
        new AddressesInitializer(abcDb).Init();
        new PersonsInitializer(abcDb).Init();
        new CountriesInitializer(abcDb).Init();
        new CurrenciesInitializer(abcDb).Init();
        new CountryCurrencyInitializer(abcDb).Init();
    }
}