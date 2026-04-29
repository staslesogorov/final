import 'package:flutter/material.dart';

final Map<String, List> navItems = {
  "Главная": [Icons.home, false],
  "Монитор ТА": [Icons.monitor, false],
  "Детальный отчеты": [Icons.edit_document, true],
  "Учет ТМЦ": [Icons.shopping_cart, true],
  "Администрирование": [Icons.settings, true],
};

final Map<String, List> subItems = {
  "Детальный отчеты": ["Детальный отчеты"],
  "Учет ТМЦ": ["Учет ТМЦ"],
  "Администрирование": [
    "Торговые автоматы",
    "Компании",
    "Пользователи",
    "Модемы",
    "Дополнительные",
  ],
};

class Menu extends StatefulWidget {
  final void Function(String) onSelect;

  const Menu({super.key, required this.onSelect});

  @override
  State<Menu> createState() => _MenuState();
}

class _MenuState extends State<Menu> {
  bool open = true;

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () => setState(() => open = !open),
      child: Container(
        color: Colors.black87,
        padding: EdgeInsets.all(20),
        child: Column(
          spacing: 20,
          mainAxisAlignment: MainAxisAlignment.start,
          crossAxisAlignment: CrossAxisAlignment.start,
          children: navItems.entries
              .map(
                (e) => MenuItem(
                  name: e.key,
                  icon: e.value[0],
                  open: open,
                  onTap: () {
                    print(e.key);
                    widget.onSelect(e.key);
                  },
                  openable: e.value[1],
                ),
              )
              .toList(),
        ),
      ),
    );
  }
}

class MenuItem extends StatefulWidget {
  final String name;
  final IconData icon;
  final bool open;
  final VoidCallback onTap;
  final bool openable;

  const MenuItem({
    super.key,
    required this.name,
    required this.icon,
    required this.open,
    required this.onTap,
    required this.openable,
  });

  @override
  State<MenuItem> createState() => _MenuItemState();
}

class _MenuItemState extends State<MenuItem> {
  bool subOpen = false;

  @override
  Widget build(BuildContext context) {
    final onTap = widget.openable
        ? () => setState(() => subOpen = !subOpen)
        : widget.onTap;
    return GestureDetector(
      onTap: onTap,
      child: Column(
        children: [
          Row(
            spacing: 20,
            mainAxisAlignment: MainAxisAlignment.start,
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Icon(widget.icon, color: Colors.white),
              if (widget.open)
                Text(
                  widget.name,
                  style: TextStyle(fontSize: 18, color: Colors.white),
                ),
              if (widget.openable && widget.open)
                Icon(
                  subOpen
                      ? Icons.keyboard_arrow_down
                      : Icons.keyboard_arrow_right,
                  color: Colors.white,
                ),
            ],
          ),
          if (subOpen && widget.open)
            Column(
              spacing: 10,
              mainAxisAlignment: MainAxisAlignment.start,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: subItems[widget.name]!
                  .map(
                    (e) => GestureDetector(
                      onTap: () => widget.onTap(),
                      child: Row(
                        spacing: 20,
                        mainAxisAlignment: MainAxisAlignment.start,
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Text(
                            e,
                            style: TextStyle(
                              fontSize: 16,
                              color: Colors.white70,
                            ),
                          ),
                        ],
                      ),
                    ),
                  )
                  .toList(),
            ),
        ],
      ),
    );
  }
}
