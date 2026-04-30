import 'dart:math';
import 'package:desktop/api.dart';
import 'package:dio/dio.dart';
import 'package:flutter/material.dart';
import 'package:graphic/graphic.dart';

class EffectivnpostSeti extends StatefulWidget {
  const EffectivnpostSeti({super.key});
  @override
  State<EffectivnpostSeti> createState() => _EffectivnpostSetiState();
}

class _EffectivnpostSetiState extends State<EffectivnpostSeti> {
  int all = 0, work = 0;

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
        work = d.where((m) => m['status'] != 'Сломан').length;
      });
    } on DioException catch (e) {}
  }

  @override
  Widget build(BuildContext context) => Padding(
    padding: EdgeInsets.all(10),
    child: Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        SizedBox(
          width: 200,
          height: 200,
          child: Chart(
            data: [
              {'t': 'Работает', 'v': work},
              {'t': 'Нет', 'v': all - work},
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
                  values: [Colors.green, Colors.red],
                ),
                modifiers: [StackModifier()],
              ),
            ],
            coord: PolarCoord(
              transposed: true,
              dimCount: 1,
              startAngle: pi,
              endAngle: 2 * pi,
            ),
          ),
        ),
        Text('Работающих автоматов ${work / all * 100}%'),
      ],
    ),
  );
}
