# ВышКат

## Запуск
dotnet restore

dotnet build

dotnet run --project src/VyShKat.Console

dotnet test

## Архитектура
Domain — сущности и абстракции.
Application — сервисы парка и техосмотра.
Console — DI-контейнер и демонстрация.
Tests — xUnit, fake-техосмотр.

## SOLID
- SRP: Transport, ServiceCenter, FleetService, App отвечают за своё.
- OCP: новый вид транспорта добавляется классом-наследником Transport без правки FleetService.
- LSP: любой Transport можно передать в FleetService.
- ISP: IInventoryItem и IEnergyConsumer разделены.
- DIP: FleetService зависит от IInspectionService, а не от ServiceCenter.

## Сознательно ограничено
ServiceCenter имеет простое правило и не конфигурируется.

## Расширение
Новый транспорт — новый класс. Сотрудник — отдельная абстракция, не IInventoryItem, т.к. сотрудники не ставятся на баланс. Склад запчастей — отдельный сервис.

## Тесты
FakeInspectionService подменяет IInspectionService в FleetServiceTests.
Тест GetTransportsForNovices_ReturnsOnlySimplicityAtLeastSix фиксирует правило новичков.
