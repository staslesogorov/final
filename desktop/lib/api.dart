import 'package:dio/dio.dart';

final dio = Dio(BaseOptions(baseUrl: 'http://localhost:5270/api/v1'));

void setToken(String t) {
  dio.options.headers['Authorization'] = 'Bearer $t';
}
