import 'package:flutter/material.dart';

final Map<String, IconData> navItems = {
  "Главная": Icons.home,
  "Монитор ТА": Icons.monitor,
  "Детальный отчеты": Icons.edit_document,
  "Учет ТМЦ": Icons.shopping_cart,
  "Администрирование": Icons.settings,
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
                  icon: e.value,
                  open: open,
                  onTap: () => widget.onSelect(e.key),
                ),
              )
              .toList(),
        ),
      ),
    );
  }
}

class MenuItem extends StatelessWidget {
  final String name;
  final IconData icon;
  final bool open;
  final VoidCallback onTap;

  const MenuItem({
    super.key,
    required this.name,
    required this.icon,
    required this.open,
    required this.onTap,
  });

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onTap,
      child: Row(
        spacing: 20,
        mainAxisAlignment: MainAxisAlignment.start,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Icon(icon, color: Colors.white),
          if (open)
            Text(name, style: TextStyle(fontSize: 18, color: Colors.white)),
        ],
      ),
    );
  }
}
