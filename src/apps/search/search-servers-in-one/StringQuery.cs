/**
 * Autogenerated by Thrift Compiler (@PACKAGE_VERSION@)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace dsn.app.search
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class StringQuery : TBase
  {
    private string _Query;

    public string Query
    {
      get
      {
        return _Query;
      }
      set
      {
        __isset.Query = true;
        this._Query = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool Query;
    }

    public StringQuery() {
    }

    public void Read (TProtocol iprot)
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.String) {
              Query = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("StringQuery");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (Query != null && __isset.Query) {
        field.Name = "Query";
        field.Type = TType.String;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Query);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("StringQuery(");
      bool __first = true;
      if (Query != null && __isset.Query) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Query: ");
        __sb.Append(Query);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
