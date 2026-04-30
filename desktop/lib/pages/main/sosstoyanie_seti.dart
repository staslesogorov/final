import 'dart:math';
import 'package:desktop/api.dart';
import 'package:dio/dio.dart';
import 'package:flutter/material.dart';
import 'package:graphic/graphic.dart';

class SosstoyanieSeti extends StatefulWidget {
  const SosstoyanieSeti({super.key});
  @override
  State<SosstoyanieSeti> createState() => _SosstoyanieSetiState();
}

class _SosstoyanieSetiState extends State<SosstoyanieSeti> {
  int all = 0, work = 0, service = 0, error = 0;
  bool loaded = false;
  @override
  void initState() {
    super.initState();
    fetch();
  }

  void fetch() async {
    try {
      final d = await dio
          .get('/VendingMachines')
          .then((res) => res.data['data']);

      setState(() {
        all = d.length;
        error = d.where((m) => m['status'] == 'Сломан').length;
        work = d.where((m) => m['status'] == 'Работает').length;
        service = d.where((m) => m['status'] == 'Обслуживается').length;
        loaded = true;
      });
    } on DioException catch (e) {}
  }

  @override
  Widget build(BuildContext context) => Padding(
    padding: EdgeInsets.all(10),
    child: Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        !loaded
            ? CircularProgressIndicator()
            : SizedBox(
                width: 200,
                height: 200,
                child: Chart(
                  data: [
                    {'t': 'Работает', 'v': work},
                    {'t': 'Обслуживается', 'v': service},
                    {'t': 'Сломан', 'v': error},
                  ],
                  variables: {
                    't': Variable(accessor: (Map m) => m['t'] as String),
                    'v': Variable(
                      accessor: (Map m) => m['v'] as num,
                      scale: LinearScale(marginMin: 0, marginMax: 0),
                    ),
                  },
                  marks: [
                    IntervalMark(
                      color: ColorEncode(
                        variable: 't',
                        values: [Colors.green, Colors.blue, Colors.red],
                      ),
                      modifiers: [StackModifier()],
                    ),
                  ],
                  coord: PolarCoord(
                    transposed: true,
                    dimCount: 1,
                    startAngle: -pi / 2,
                    endAngle: 3 * pi / 2,
                  ),
                ),
              ),
      ],
    ),
  );
}
