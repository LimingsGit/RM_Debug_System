#ifndef __WIFI_H
#define __WIFI_H	 
#include "delay.h"

//����
#define VEHICLE_TYPE_MATRIX 1
//Ӣ�۳�
#define VEHICLE_TYPE_HERO 2
//���̳�
#define VEHICLE_TYPE_ENGINEER 3
//����վ
#define VEHICLE_TYPE_DEPOT 4
//������1
#define VEHICLE_TYPE_PACER_1 5
//������2
#define VEHICLE_TYPE_PACER_2 6
//������3
#define VEHICLE_TYPE_PACER_3 7

//����connect_id
#define DATA_PART_1_LENGTH 6
//���̵��12�ĵ������ٶȡ�������Ϣ
#define DATA_PART_2_LENGTH 11
//���̵��34�ĵ������ٶȡ�������Ϣ
#define DATA_PART_3_LENGTH 11
//��̨yaw���pitch����ĵ������ٶȡ�λ����Ϣ
#define DATA_PART_4_LENGTH 11
//��������ĵ������ٶȡ�λ����Ϣ+Ħ���ֵ���ĵ������ٶ���Ϣ
#define DATA_PART_5_LENGTH 12

//�򵥵�PID�ṹ��
typedef struct{
	float kp;
	float ki;
	float kd;
}Simple_PID_TypeDef;

//���״̬��Ϣ�ṹ��
typedef struct{
	float i;//����
	float v;//�ٶ�
	float s;//λ��
	float p;//����
}Motor_Condition_TypeDef;

//������״̬��Ϣ�ṹ��
typedef struct 
{
	//���̵��1״̬��Ϣ
	Motor_Condition_TypeDef chassis_motor1_condition;
	//���̵��2״̬��Ϣ
	Motor_Condition_TypeDef chassis_motor2_condition;
	//���̵��3״̬��Ϣ
	Motor_Condition_TypeDef chassis_motor3_condition;
	//���̵��4״̬��Ϣ
	Motor_Condition_TypeDef chassis_motor4_condition;
	//��̨���yaw��״̬��Ϣ
	Motor_Condition_TypeDef cradle_yaw_motor_condition;
	//��̨���pitch��״̬��Ϣ
	Motor_Condition_TypeDef cradle_pitch_motor_condition;
	//�������״̬��Ϣ
	Motor_Condition_TypeDef rammer_motor_condition;
	//Ħ���ֵ��1״̬��Ϣ
	Motor_Condition_TypeDef shooter1_motor_condition;
	//Ħ���ֵ��2״̬��Ϣ
	Motor_Condition_TypeDef shooter2_motor_condition;
}Pacer_Vehicle_Condition_TypeDef;
//////////////////////////////////////////////////////////////////////////////////	 

////////////////////////////////////////////////////////////////////////////////// 

void init_Wifi(u8,char*);//��ʼ��
void send_WifiData(char*);
void printNewLine(void);
//����wifi���ͱ�ʶ�����ж���ÿ1ms����һ��
void update_wifi_send_flag(void);
//�����������е��״̬��Ϣ����λ��
void send_motor_conditions(Motor_Condition_TypeDef* chassis_motor1_condition
	,Motor_Condition_TypeDef* chassis_motor2_condition
	,Motor_Condition_TypeDef* chassis_motor3_condition
	,Motor_Condition_TypeDef* chassis_motor4_condition
	,Motor_Condition_TypeDef* cradle_yaw_motor_condition
	,Motor_Condition_TypeDef* cradle_pitch_motor_condition
	,Motor_Condition_TypeDef* rammer_motor_condition
	,Motor_Condition_TypeDef* shooter1_motor_condition
	,Motor_Condition_TypeDef* shooter2_motor_condition
	);
//ȡ�ó�ʼ���ĵ��״̬��Ϣ�ṹ��
Motor_Condition_TypeDef get_default_motor_conditon(void);
//ȡ�ó�ʼ���Ĳ�����״̬��Ϣ�ṹ��
Pacer_Vehicle_Condition_TypeDef get_default_pacer_vehicle_conditon(void);
//���Ͳ�����״̬��Ϣ����λ��
void send_pacer_vihecle_condition(Pacer_Vehicle_Condition_TypeDef* pacer_vehicle_condition);
//��main�����������Ƶ�ʵ���
void always_send(void);
//�����յ���connect_id
void handle_connect_id(u8 id);   
//�����յ��ĵ��̵��1�ĵ��������ٶȻ������ʻ�pid����
void handle_chassis_motor1_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v,Simple_PID_TypeDef* pid_p);
//�����յ��ĵ��̵��2�ĵ��������ٶȻ������ʻ�pid����
void handle_chassis_motor2_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v,Simple_PID_TypeDef* pid_p);
//�����յ��ĵ��̵��3�ĵ��������ٶȻ������ʻ�pid����
void handle_chassis_motor3_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v,Simple_PID_TypeDef* pid_p);
//�����յ��ĵ��̵��4�ĵ��������ٶȻ������ʻ�pid����
void handle_chassis_motor4_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v,Simple_PID_TypeDef* pid_p);
//�����յ�����̨yaw�����ĵ��������ٶȻ���λ�û�pid����
void handle_cradle_yaw_motor_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v,Simple_PID_TypeDef* pid_s);
//�����յ�����̨pitch�����ĵ��������ٶȻ���λ�û�pid����
void handle_cradle_pitch_motor_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v,Simple_PID_TypeDef* pid_s);
//�����յ��Ĳ�������ĵ��������ٶȻ���λ�û�pid����
void handle_rammer_motor_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v,Simple_PID_TypeDef* pid_s);
//�����յ���Ħ���ֵ��1�ĵ��������ٶȻ�����
void handle_shooter1_motor_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v);
//�����յ���Ħ���ֵ��2�ĵ��������ٶȻ�����
void handle_shooter2_motor_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v);

#endif
