using Nursery.commands;
using Nursery.controller;
using Nursery.view;

View view = new View();
UICommands uICommands = new UICommands(view);
Controller controller = new Controller(view, uICommands);

controller.Execute();
