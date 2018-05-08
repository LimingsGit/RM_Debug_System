#include "wifi.h"
#define INTERVAL 5

u8 connect_id=0;
u8 vehicle_type;
u8 data_length=DATA_PART_1_LENGTH+DATA_PART_2_LENGTH+DATA_PART_3_LENGTH+DATA_PART_4_LENGTH+DATA_PART_5_LENGTH;
u8 wifi_send_flag;
u32 send_wifi_count;
u16 wifi_data[DATA_PART_1_LENGTH
	+DATA_PART_2_LENGTH
	+DATA_PART_3_LENGTH
	+DATA_PART_4_LENGTH
	+DATA_PART_5_LENGTH];
void delay_s(u16 n)
{
	u16 i=0;
	for(i=0;i<n;i++)
	{
		delay_ms(1000);
	}
}
void printNewLine(){
	printf("\r\n");
}
void init_Wifi(u8 vehicle_type_arg,char* server_ip){
	int i;
	for(i=0;i<data_length;i++)
	{
		wifi_data[i]=0;
	}
	
	printf("AT+CWMODE=1");
	printNewLine();
	delay_ms(200);

	vehicle_type=vehicle_type_arg;
	printf("AT+RST");
	printNewLine();
	delay_ms(400);
	
	//printf("AT+CWJAP=\"TP-LINK_9145C7\",\"123456323\"");
	printf("AT+CWJAP=\"CMCC\",\"wangduishitiancai\"");
	printNewLine();
	delay_s(12);
	
	printf("AT+CIPMUX=0");
	printNewLine();
	delay_ms(500);
	
	//printf("AT+CIPCLOSE");
	//printNewLine();
	//delay_s(INTERVAL);
	
	printf("AT+CIPSTART=\"TCP\",\"%s\",555",server_ip);
	printNewLine();
	delay_ms(1000);
	
	//printf("AT+CIPSTO=3600");
	//printNewLine();
	//delay_s(INTERVAL);
	
	printf("AT+CIPSEND=8");
	printNewLine();
	delay_ms(500);
	
	printf("succeed!");
	printNewLine();
	delay_ms(500);
}
void send_WifiData(char *s)
{
	//printf("AT+CIPSTART=\"TCP\",\"192.168.1.121\",555");
	//printNewLine();
	//delay_ms(1000);
	
	printf("AT+CIPSEND=%d",strlen(s));
	printNewLine();
	delay_ms(500);
	
	printf("%s",s);
	printNewLine();
	delay_ms(500);
}
u32 send_wifi_count=0;
u32 recorded_wifi_count=0;
u8 wifi_send_flag=0;
void update_wifi_send_flag(){
	send_wifi_count++;
	if(send_wifi_count==1){
			printf("AT+CIPSEND=%d",data_length+2);
			printNewLine();
			send_wifi_count++;
		}
}
void send_motor_conditions(Motor_Condition_TypeDef* chassis_motor1_condition
	,Motor_Condition_TypeDef* chassis_motor2_condition
	,Motor_Condition_TypeDef* chassis_motor3_condition
	,Motor_Condition_TypeDef* chassis_motor4_condition
	,Motor_Condition_TypeDef* cradle_yaw_motor_condition
	,Motor_Condition_TypeDef* cradle_pitch_motor_condition
	,Motor_Condition_TypeDef* rammer_motor_condition
	,Motor_Condition_TypeDef* shooter1_motor_condition
	,Motor_Condition_TypeDef* shooter2_motor_condition
	)
{
	u16 data_part_1[DATA_PART_1_LENGTH];
	u16 data_part_2[DATA_PART_2_LENGTH];
	u16 data_part_3[DATA_PART_3_LENGTH];
	u16 data_part_4[DATA_PART_4_LENGTH];
	u16 data_part_5[DATA_PART_5_LENGTH];
	u16 scale=256;
	int i,count=0;
	//part1:����connect_id
	data_part_1[0]=0xFF;
	data_part_1[1]=0xFF;
	switch(vehicle_type){
		case VEHICLE_TYPE_MATRIX:
		data_part_1[2]=0xFF;
		break;
		case VEHICLE_TYPE_HERO:
		data_part_1[2]=0xFF;
		break;
		case VEHICLE_TYPE_ENGINEER:
		data_part_1[2]=0xFF;
		break;
		case VEHICLE_TYPE_DEPOT:
		data_part_1[2]=0xFF;
		break;
		case VEHICLE_TYPE_PACER_1:
		data_part_1[2]=0x0E;
		break;
		case VEHICLE_TYPE_PACER_2:
		data_part_1[2]=0x0F;
		break;
		case VEHICLE_TYPE_PACER_3:
		data_part_1[2]=0x10;
		break;
		default:

		break;
	}
	data_part_1[3]=0x01;
	data_part_1[4]=connect_id;
	//У��λ
	data_part_1[5]=0x00;
	for(i=0;i<DATA_PART_1_LENGTH-1;i++){
		data_part_1[5]+=data_part_1[i];
	}
	//part2:���̵��12�ĵ������ٶȡ�������Ϣ
	data_part_2[0]=0xFF;
	data_part_2[1]=0xFF;
	data_part_2[2]=0x01;
	data_part_2[3]=0x06;
	data_part_2[4]=(u16)(scale*chassis_motor1_condition->i);
	data_part_2[5]=(u16)(scale*chassis_motor1_condition->v);
	data_part_2[6]=(u16)(scale*chassis_motor1_condition->p);
	data_part_2[7]=(u16)(scale*chassis_motor2_condition->i);
	data_part_2[8]=(u16)(scale*chassis_motor2_condition->v);
	data_part_2[9]=(u16)(scale*chassis_motor2_condition->p);
	//У��λ
	data_part_2[10]=0x00;
	for(i=0;i<DATA_PART_2_LENGTH-1;i++){
		data_part_2[10]+=data_part_2[i];
	}
	//part3:���̵��34�ĵ������ٶȡ�������Ϣ
	data_part_3[0]=0xFF;
	data_part_3[1]=0xFF;
	data_part_3[2]=0x02;
	data_part_3[3]=0x06;
	data_part_3[4]=(u16)(scale*chassis_motor3_condition->i);
	data_part_3[5]=(u16)(scale*chassis_motor3_condition->v);
	data_part_3[6]=(u16)(scale*chassis_motor3_condition->p);
	data_part_3[7]=(u16)(scale*chassis_motor4_condition->i);
	data_part_3[8]=(u16)(scale*chassis_motor4_condition->v);
	data_part_3[9]=(u16)(scale*chassis_motor4_condition->p);
	//У��λ
	data_part_3[10]=0x00;
	for(i=0;i<DATA_PART_3_LENGTH-1;i++){
		data_part_3[10]+=data_part_3[i];
	}
	//part4:��̨yaw���pitch����ĵ������ٶȡ�λ����Ϣ
	data_part_4[0]=0xFF;
	data_part_4[1]=0xFF;
	data_part_4[2]=0x03;
	data_part_4[3]=0x06;
	data_part_4[4]=(u16)(scale*cradle_yaw_motor_condition->i);
	data_part_4[5]=(u16)(scale*cradle_yaw_motor_condition->v);
	data_part_4[6]=(u16)(scale*cradle_yaw_motor_condition->s);
	data_part_4[7]=(u16)(scale*cradle_pitch_motor_condition->i);
	data_part_4[8]=(u16)(scale*cradle_pitch_motor_condition->v);
	data_part_4[9]=(u16)(scale*cradle_pitch_motor_condition->s);
	//У��λ
	data_part_4[10]=0x00;
	for(i=0;i<DATA_PART_4_LENGTH-1;i++){
		data_part_4[10]+=data_part_4[i];
	}
	//part5:��������ĵ������ٶȡ�λ����Ϣ+Ħ���ֵ���ĵ������ٶ���Ϣ
	data_part_5[0]=0xFF;
	data_part_5[1]=0xFF;
	data_part_5[2]=0x04;
	data_part_5[3]=0x07;
	data_part_5[4]=(u16)(scale*rammer_motor_condition->i);
	data_part_5[5]=(u16)(scale*rammer_motor_condition->v);
	data_part_5[6]=(u16)(scale*rammer_motor_condition->s);
	data_part_5[7]=(u16)(scale*shooter1_motor_condition->i);
	data_part_5[8]=(u16)(scale*shooter1_motor_condition->v);
	data_part_5[9]=(u16)(scale*shooter2_motor_condition->i);
	data_part_5[10]=(u16)(scale*shooter2_motor_condition->v);
	//У��λ
	data_part_5[11]=0x00;
	for(i=0;i<DATA_PART_5_LENGTH-1;i++){
		data_part_5[11]+=data_part_5[i];
	}
	//�ϲ��������ֵ�����
	for(i=0;i<DATA_PART_1_LENGTH;i++)
	{
		wifi_data[count++]=data_part_1[i];
	}
	for(i=0;i<DATA_PART_2_LENGTH;i++)
	{
		wifi_data[count++]=data_part_2[i];
	}
	for( i=0;i<DATA_PART_3_LENGTH;i++)
	{
		wifi_data[count++]=data_part_3[i];
	}
	for( i=0;i<DATA_PART_4_LENGTH;i++)
	{
		wifi_data[count++]=data_part_4[i];
	}
	for( i=0;i<DATA_PART_5_LENGTH;i++)
	{
		wifi_data[count++]=data_part_5[i];
	}
	wifi_send_flag=1;
}
//��ȡĬ�ϵĵ��״̬��Ϣ�ṹ��
Motor_Condition_TypeDef get_default_motor_conditon()
{
	Motor_Condition_TypeDef motor_condition;
	motor_condition.i=0;
	motor_condition.v=0;
	motor_condition.s=0;
	motor_condition.p=0;
	return motor_condition;
}
//��ȡĬ�ϵĲ�������Ϣ�ṹ��
Pacer_Vehicle_Condition_TypeDef get_default_pacer_vehicle_conditon()
{
	Pacer_Vehicle_Condition_TypeDef pacer_vehicle_condition;
	Motor_Condition_TypeDef motor_condition;
	motor_condition=get_default_motor_conditon();
	pacer_vehicle_condition.chassis_motor1_condition=motor_condition;
	pacer_vehicle_condition.chassis_motor2_condition=motor_condition;
	pacer_vehicle_condition.chassis_motor3_condition=motor_condition;
	pacer_vehicle_condition.chassis_motor4_condition=motor_condition;
	pacer_vehicle_condition.cradle_yaw_motor_condition=motor_condition;
	pacer_vehicle_condition.cradle_pitch_motor_condition=motor_condition;
	pacer_vehicle_condition.rammer_motor_condition=motor_condition;
	pacer_vehicle_condition.shooter1_motor_condition=motor_condition;
	pacer_vehicle_condition.shooter2_motor_condition=motor_condition;
	return pacer_vehicle_condition;
}
void send_pacer_vihecle_condition(Pacer_Vehicle_Condition_TypeDef* pacer_vehicle_condition)
{
	send_motor_conditions(&pacer_vehicle_condition->chassis_motor1_condition
	,&pacer_vehicle_condition->chassis_motor2_condition
	,&pacer_vehicle_condition->chassis_motor3_condition
	,&pacer_vehicle_condition->chassis_motor4_condition
	,&pacer_vehicle_condition->cradle_yaw_motor_condition
	,&pacer_vehicle_condition->cradle_pitch_motor_condition
	,&pacer_vehicle_condition->rammer_motor_condition
	,&pacer_vehicle_condition->shooter1_motor_condition
	,&pacer_vehicle_condition->shooter2_motor_condition
	);
}
void always_send()
{
	if(wifi_send_flag==1){
		
		if(send_wifi_count>=500){
			int i;
			USART_SendData(USART2,0xAA);
			while(USART_GetFlagStatus(USART2,USART_FLAG_TC)!=SET);
			for(i=0;i<data_length;i++){
				USART_SendData(USART2,wifi_data[i]);
				while(USART_GetFlagStatus(USART2,USART_FLAG_TC)!=SET);
			}
			USART_SendData(USART2,0xAA);
			while(USART_GetFlagStatus(USART2,USART_FLAG_TC)!=SET);
			send_wifi_count=0;
			wifi_send_flag=0;
		}
	}
}
//�����յ���connect_id
void handle_connect_id(u8 id)
{
	connect_id=id;
}
/////////////////////////////////////////////////////////////
///
///���º����������ʵ�֣���Щ�����ڴ����ж��б����ã�����ʱ
///
/////////////////////////////////////////////////////////////
//�����յ��ĵ��̵��1�ĵ��������ٶȻ������ʻ�pid����
void handle_chassis_motor1_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v,Simple_PID_TypeDef* pid_p)
{
	//printf("motor1:pid_i:%f,%f,%f;",pid_i->kp,pid_i->ki,pid_i->kd);
	//printf("motor1:pid_v:%f,%f,%f;",pid_v->kp,pid_v->ki,pid_v->kd);
	//printf("motor1:pid_p:%f,%f,%f;",pid_p->kp,pid_p->ki,pid_p->kd);
}
//�����յ��ĵ��̵��2�ĵ��������ٶȻ������ʻ�pid����
void handle_chassis_motor2_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v,Simple_PID_TypeDef* pid_p)
{
	//printf("motor2:pid_i:%f,%f,%f;",pid_i->kp,pid_i->ki,pid_i->kd);
	//printf("motor2:pid_v:%f,%f,%f;",pid_v->kp,pid_v->ki,pid_v->kd);
	//printf("motor2:pid_p:%f,%f,%f;",pid_p->kp,pid_p->ki,pid_p->kd);
}
//�����յ��ĵ��̵��3�ĵ��������ٶȻ������ʻ�pid����
void handle_chassis_motor3_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v,Simple_PID_TypeDef* pid_p)
{
	//printf("motor3:pid_i:%f,%f,%f;",pid_i->kp,pid_i->ki,pid_i->kd);
	//printf("motor3:pid_v:%f,%f,%f;",pid_v->kp,pid_v->ki,pid_v->kd);
	//printf("motor3:pid_p:%f,%f,%f;",pid_p->kp,pid_p->ki,pid_p->kd);
}
//�����յ��ĵ��̵��4�ĵ��������ٶȻ������ʻ�pid����
void handle_chassis_motor4_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v,Simple_PID_TypeDef* pid_p)
{
	//printf("motor4:pid_i:%f,%f,%f;",pid_i->kp,pid_i->ki,pid_i->kd);
	//printf("motor4:pid_v:%f,%f,%f;",pid_v->kp,pid_v->ki,pid_v->kd);
	//printf("motor4:pid_p:%f,%f,%f;",pid_p->kp,pid_p->ki,pid_p->kd);
}
//�����յ�����̨yaw�����ĵ��������ٶȻ���λ�û�pid����
void handle_cradle_yaw_motor_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v,Simple_PID_TypeDef* pid_s)
{
	//printf("yaw_motor:pid_i:%f,%f,%f;",pid_i->kp,pid_i->ki,pid_i->kd);
	//printf("yaw_motor:pid_v:%f,%f,%f;",pid_v->kp,pid_v->ki,pid_v->kd);
	//printf("yaw_motor:pid_s:%f,%f,%f;",pid_s->kp,pid_s->ki,pid_s->kd);
}
//�����յ�����̨pitch�����ĵ��������ٶȻ���λ�û�pid����
void handle_cradle_pitch_motor_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v,Simple_PID_TypeDef* pid_s)
{
	//printf("pitch_motor:pid_i:%f,%f,%f;",pid_i->kp,pid_i->ki,pid_i->kd);
	//printf("pitch_motor:pid_v:%f,%f,%f;",pid_v->kp,pid_v->ki,pid_v->kd);
	//printf("pitch_motor:pid_s:%f,%f,%f;",pid_s->kp,pid_s->ki,pid_s->kd);
}
//�����յ��Ĳ�������ĵ��������ٶȻ���λ�û�pid����
void handle_rammer_motor_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v,Simple_PID_TypeDef* pid_s)
{
	//printf("rammer_motor:pid_i:%f,%f,%f;",pid_i->kp,pid_i->ki,pid_i->kd);
	//printf("rammer_motor:pid_v:%f,%f,%f;",pid_v->kp,pid_v->ki,pid_v->kd);
	//printf("rammer_motor:pid_s:%f,%f,%f;",pid_s->kp,pid_s->ki,pid_s->kd);
}
//�����յ���Ħ���ֵ��1�ĵ��������ٶȻ�����
void handle_shooter1_motor_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v)
{
	//printf("shooter1_motor:pid_i:%f,%f,%f;",pid_i->kp,pid_i->ki,pid_i->kd);
	//printf("shooter1_motor:pid_v:%f,%f,%f;",pid_v->kp,pid_v->ki,pid_v->kd);
}
//�����յ���Ħ���ֵ��2�ĵ��������ٶȻ�����
void handle_shooter2_motor_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v)
{
	//printf("shooter2_motor:pid_i:%f,%f,%f;",pid_i->kp,pid_i->ki,pid_i->kd);
	//printf("shooter2_motor:pid_v:%f,%f,%f;",pid_v->kp,pid_v->ki,pid_v->kd);
}
