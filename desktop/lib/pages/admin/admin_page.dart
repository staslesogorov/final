import 'package:desktop/api.dart';
import 'package:dio/dio.dart';
import 'package:flutter/material.dart';

class AdminPage extends StatefulWidget {
  const AdminPage({super.key});
  @override
  State<AdminPage> createState() => _AdminPageState();
}

class _AdminPageState extends State<AdminPage> {
  List machines = [];

  @override
  void initState() {
    super.initState();
    fetch();
  }

  void fetch() async {
    try {
      final res = await dio
          .get('/VendingMachines')
          .then((res) => res.data['data']);
      setState(() {
        machines = res;
      });
    } on DioException catch (e) {}
  }

  void Delete(id) async {
    try {
      await dio.delete('/VendingMachines/$id');
      fetch();
    } on DioException catch (e) {}
  }

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: DataTable(
        columns: [
          DataColumn(label: Text('ID')),
          DataColumn(label: Text('Название')),
          DataColumn(label: Text('Модель')),
          DataColumn(label: Text('Компания')),
          DataColumn(label: Text('Модем')),
          DataColumn(label: Text('Адрес/Место')),
          DataColumn(label: Text('В работе с')),
          DataColumn(label: Text('Действия')),
        ],
        rows: List.generate(machines.length, (i) {
          final m = machines[i];
          return DataRow(
            color: WidgetStateProperty.all(
              i.isEven ? Colors.white : Colors.grey[200]!,
            ),
            cells: [
              DataCell(SizedBox(width: 50, child: Text(m['id']))),
              DataCell(SizedBox(width: 50, child: Text(m['name']))),
              DataCell(SizedBox(width: 50, child: Text(m['model']))),
              DataCell(SizedBox(width: 50, child: Text(m['company']))),
              DataCell(SizedBox(width: 50, child: Text(m['serialNumber']))),
              DataCell(SizedBox(width: 50, child: Text(m['place']))),
              DataCell(SizedBox(width: 50, child: Text(m['date']))),
              DataCell(
                Row(
                  children: [
                    IconButton(icon: Icon(Icons.edit), onPressed: () {}),
                    IconButton(
                      icon: Icon(Icons.delete),
                      onPressed: () {
                        Delete(m['id']);
                      },
                    ),
                  ],
                ),
              ),
            ],
          );
        }),
      ),
    );
  }
}
