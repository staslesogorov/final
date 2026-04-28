import 'package:desktop/api.dart';
import 'package:desktop/user.dart';
import 'package:dio/dio.dart';
import 'package:flutter/material.dart';

class LoginPage extends StatefulWidget {
  const LoginPage({super.key});
  @override
  State<LoginPage> createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  final login = TextEditingController();
  final pass = TextEditingController();

  String? error;

  void click() async {
    try {
      final res = await dio.post(
        '/auth/login',
        data: {'login': login.text, 'password': pass.text},
      );
      setToken(res.data['data']['token']);
      final user = User(
        fio: res.data['data']['user']['fio'],
        role: res.data['data']['user']['role'],
      );
      setUser(user);
      Navigator.pushReplacementNamed(context, '/home');
    } on DioException catch (e) {
      setState(() {
        error = e.response?.data['error'];
      });
    }
  }

  @override
  Widget build(BuildContext context) => Scaffold(
    body: Center(
      child: SizedBox(
        width: 200,
        child: Column(
          mainAxisSize: MainAxisSize.min,
          spacing: 10,
          children: [
            TextField(controller: login),
            TextField(controller: pass),
            if (error != null)
              Text(error!, style: TextStyle(color: Colors.red)),
            ElevatedButton(onPressed: click, child: Text('Войти')),
          ],
        ),
      ),
    ),
  );
}
